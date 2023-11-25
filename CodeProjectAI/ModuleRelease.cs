namespace CodeProjectAI
{
    /// <summary>
    /// Holds information on a given release of a module.
    /// </summary>
    public class ModuleRelease
    {
        /// <summary>
        /// The version of a module
        /// </summary>
        public string? ModuleVersion { get; set; }

        /// <summary>
        /// The Inclusive range of server versions for which this module version can be installed on
        /// </summary>
        public string[]? ServerVersionRange { get; set; }

        /// <summary>
        /// The date this version was released
        /// </summary>
        public string? ReleaseDate { get; set; }

        /// <summary>
        /// Any notes associated with this release
        /// </summary>
        public string? ReleaseNotes { get; set; }

        /// <summary>
        /// Gets or sets a string indicating how important this update is.
        /// </summary>
        public string? Importance { get; set; }
    }
}
