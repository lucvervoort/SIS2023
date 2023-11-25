namespace CodeProjectAI
{
    public class VersionUpdateResponse : VersionResponse
    {
        /// <summary>
        /// Whether or not a new version is available
        /// </summary>
        public bool? updateAvailable { get; set; }

        /// <summary>
        /// The latest version available for download
        /// </summary>
        public VersionInfo? latest { get; set; }

        /// <summary>
        /// The current version of this server
        /// </summary>
        public VersionInfo? current { get; set; }
    }
}
