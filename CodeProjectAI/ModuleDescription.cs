namespace CodeProjectAI
{
    /// <summary>
    /// A description of a downloadable AI analysis module.
    /// </summary>
    public class ModuleDescription : ModuleBase
    {
        /// <summary>
        /// Gets or sets the URL from where this module can be downloaded. This could be included in
        /// the modules.json file that ultimately populates this object, but more likely this value
        /// will be set by the server at some point.
        /// </summary>
        public string? DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets the status of this module.
        /// </summary>
        public ModuleStatusType? Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the module represented in this description can
        /// actually be downloaded (as opposed to being side-loaded or uploaded by a user)
        /// </summary>
        public bool IsDownloadable { get; set; } = true;

        /// <summary>
        /// Gets or sets the number of downloads of this module. This could be included in the
        /// modules.json file that ultimately populates this object, but more likely this value
        /// will be set by the server at some point.
        /// </summary>
        public int Downloads { get; set; }

        /// <summary>
        /// Gets or sets the ModuleRelease of the latest release of this module that is compatible
        /// with the current server. This value is not deserialised, but instead must be set by the
        /// server.
        /// </summary>
        public ModuleRelease? LatestRelease { get; set; }

        /// <summary>
        /// Gets a value indicating whether or not this is a valid module that can actually be
        /// started.
        /// </summary>
        public bool Valid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ModuleId) &&
                       !string.IsNullOrWhiteSpace(DownloadUrl) &&
                       !string.IsNullOrWhiteSpace(Name) &&
                       Platforms?.Length > 0;
            }
        }
    }
}
