namespace CodeProjectAI
{
    public class SettingsResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the module's environment variables
        /// </summary>
        public IDictionary<string, string?>? environmentVariables { get; set; }

        /// <summary>
        /// Gets or sets the module's settings
        /// </summary>
        public dynamic? settings { get; set; }
    }
}
