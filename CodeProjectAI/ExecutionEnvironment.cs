namespace CodeProjectAI
{
    public enum ExecutionEnvironment
    {
        /// <summary>
        /// Unknown execution environment
        /// </summary>
        Unknown,

        /// <summary>
        /// Running in Docker
        /// </summary>
        Docker,

        /// <summary>
        /// Running in Visual Studio Code
        /// </summary>
        VSCode,

        /// <summary>
        /// Running in Visual Studio
        /// </summary>
        VisualStudio,

        /// <summary>
        /// Running natively within the host OS
        /// </summary>
        Native
    }
}
