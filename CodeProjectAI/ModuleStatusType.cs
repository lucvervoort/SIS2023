using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CodeProjectAI
{
    /// <summary>
    /// Describes the installation status of a module
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ModuleStatusType
    {
        /// <summary>
        /// No idea what's happening.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0,

        /// <summary>
        /// Not available. Maybe not valid, maybe not available on this platform.
        /// </summary>
        [EnumMember(Value = "NotAvailable")]
        NotAvailable,

        /// <summary>
        /// Is available to be downloaded and installed on this platform.
        /// </summary>
        [EnumMember(Value = "Available")]
        Available,

        /// <summary>
        /// An update to an already-installed module is available to be downloaded and installed
        /// on this platform.
        /// </summary>
        [EnumMember(Value = "UpdateAvailable")]
        UpdateAvailable,

        /// <summary>
        /// Currently downloading from the registry
        /// </summary>
        [EnumMember(Value = "Downloading")]
        Downloading,

        /// <summary>
        /// Unpacking the downloaded model and prepping for install
        /// </summary>
        [EnumMember(Value = "Unpacking")]
        Unpacking,

        /// <summary>
        /// Installing the module
        /// </summary>
        [EnumMember(Value = "Installing")]
        Installing,

        /// <summary>
        /// Tried to install but failed to install in a way that allowed a successful start
        /// </summary>
        [EnumMember(Value = "FailedInstall")]
        FailedInstall,

        /// <summary>
        /// Off to the races
        /// </summary>
        [EnumMember(Value = "Installed")]
        Installed,

        /// <summary>
        /// Stopping and uninstalling this module.
        /// </summary>
        [EnumMember(Value = "Uninstalling")]
        Uninstalling,

        /// <summary>
        /// Tried to uninstall but failed.
        /// </summary>
        [EnumMember(Value = "UninstallFailed")]
        UninstallFailed,

        /// <summary>
        /// Was installed, but no longer. Completely Uninstalled.
        /// </summary>
        [EnumMember(Value = "Uninstalled")]
        Uninstalled
    }
}
