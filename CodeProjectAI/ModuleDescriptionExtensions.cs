namespace CodeProjectAI
{
    /// <summary>
    /// Extension methods for the ModuleDescription class
    /// </summary>
    public static class ModuleDescriptionExtensions
    {
        /// <summary>
        /// ModuleDescription objects are typically created by deserialising a JSON file so we don't
        /// get a chance at create time to supply supplementary information or adjust values that
        /// may not have been set (eg moduleId). Specifically, this function will set the status and
        /// the ModulePath / WorkingDirectory, as well as setting the latest compatible version from
        /// the module's ModuleRelease list. But this could change without notice.
        /// </summary>
        /// <param name="module">This module that requires initialisation</param>
        /// <param name="currentServerVersion">The current version of the server</param>
        /// <param name="modulesPath">The path to the folder containing all downloaded and installed
        /// modules</param>
        /// <param name="preInstalledModulesPath">The path to the folder containing all pre-installed
        /// modules</param>
        /// <remarks>Modules are usually downloaded and installed in the modulesPAth, but we can
        /// 'pre-install' them in situations like a Docker image. We pre-install modules in a
        /// separate folder than the downloaded and installed modules in order to avoid conflicts 
        /// (in Docker) when a user maps a local folder to the modules dir. Doing this to the 'pre
        /// installed' dir would make the contents (the preinstalled modules) disappear.</remarks>
        public static void Initialise(this ModuleDescription module, string currentServerVersion,
                                      string modulesPath, string preInstalledModulesPath)
        {
            // Currently these are unused. There are here only as an experiment
            if (module.PreInstalled)
                module.ModulePath = Path.Combine(preInstalledModulesPath, module.ModuleId!);
            else
                module.ModulePath = Path.Combine(modulesPath, module.ModuleId!);
            module.WorkingDirectory = module.ModulePath; // This once was allowed to be different to ModulePath

            // Find the most recent version of this module that's compatible with the current server
            SetLatestCompatibleVersion(module, currentServerVersion);

            // Set the status of all entries based on availability on this platform
            module.Status = string.IsNullOrWhiteSpace(module?.LatestRelease?.ModuleVersion)
                          || !module.IsAvailable(SystemInfo.Platform, currentServerVersion)
                          ? ModuleStatusType.NotAvailable : ModuleStatusType.Available;
        }

        /// <summary>
        /// Gets a value indicating whether or not this module is actually available. This depends 
        /// on having valid commands, settings, and importantly, being supported on this platform.
        /// </summary>
        /// <param name="module">This module</param>
        /// <param name="platform">The platform being tested</param>
        /// <param name="serverVersion">The version of the server, or null to ignore version issues</param>
        /// <returns>true if the module is available; false otherwise</returns>
        public static bool IsAvailable(this ModuleDescription module, string platform, string? serverVersion)
        {
            if (module is null)
                return false;

            // First check: Is there a version of this module that's compatible with the current server?
            if (serverVersion is not null && string.IsNullOrWhiteSpace(module?.LatestRelease?.ModuleVersion))
                SetLatestCompatibleVersion(module!, serverVersion);

            bool versionOK = serverVersion is null ||
                             !string.IsNullOrWhiteSpace(module?.LatestRelease?.ModuleVersion);

            // Second check: Is this module available on this platform?
            return module!.Valid && versionOK &&
                   (module.Platforms!.Any(p => p.EqualsIgnoreCase("all")) ||
                     module.Platforms!.Any(p => p.EqualsIgnoreCase(platform)));
        }

        private static void SetLatestCompatibleVersion(ModuleDescription module, string currentServerVersion)
        {
            // HACK: To be removed after CPAI 2.1 is released. The Versions array wasn't added to
            // the downloadable list of modules until server version 2.1. All modules pre-server
            // 2.1 are compatible with server 2.1+, so 
            if ((module.ModuleReleases?.Length ?? 0) == 0)
            {
                module.LatestRelease = new ModuleRelease()
                {
                    ModuleVersion = module.Version,
                    ReleaseDate = "2022-03-20"
                };
                return;
            }

            foreach (ModuleRelease release in module!.ModuleReleases!)
            {
                if (release.ServerVersionRange is null || release.ServerVersionRange.Length < 2)
                    continue;

                string? minServerVersion = release.ServerVersionRange[0];
                string? maxServerVersion = release.ServerVersionRange[1];

                if (string.IsNullOrEmpty(minServerVersion)) minServerVersion = "0.0";
                if (string.IsNullOrEmpty(maxServerVersion)) maxServerVersion = currentServerVersion;

                if (VersionInfo.Compare(minServerVersion, currentServerVersion) <= 0 &&
                    VersionInfo.Compare(maxServerVersion, currentServerVersion) >= 0)
                {
                    if (module.LatestRelease is null ||
                        VersionInfo.Compare(module.LatestRelease.ModuleVersion, release.ModuleVersion) <= 0)
                    {
                        module.LatestRelease = release;
                    }
                }
            }
        }
    }
}
