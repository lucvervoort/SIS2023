using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace CodeProjectAI
{
    /// <summary>
    /// Describes the state of a proces that is running a module
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProcessStatusType
    {
        /// <summary>
        /// No idea what's happening.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0,

        /// <summary>
        /// Not enabled (but available to be enabled)
        /// </summary>
        [EnumMember(Value = "NotEnabled")]
        NotEnabled,

        /// <summary>
        /// Not available. Maybe not valid, maybe not available on this platform.
        /// </summary>
        [EnumMember(Value = "NotAvailable")]
        NotAvailable,

        /// <summary>
        /// Good to go
        /// </summary>
        [EnumMember(Value = "Enabled")]
        Enabled,

        /// <summary>
        /// It's ready to rock and/or roll but wasn't started (maybe due to debugging settings)
        /// </summary>
        [EnumMember(Value = "NotStarted")]
        NotStarted,

        /// <summary>
        /// Starting up, but not yet started
        /// </summary>
        [EnumMember(Value = "Starting")]
        Starting,

        /// <summary>
        /// Off to the races
        /// </summary>
        [EnumMember(Value = "Started")]
        Started,

        /// <summary>
        /// Oh that's not good
        /// </summary>
        [EnumMember(Value = "FailedStart")]
        FailedStart,

        /// <summary>
        /// That's even worse
        /// </summary>
        [EnumMember(Value = "Crashed")]
        Crashed,

        /// <summary>
        /// A controlled stop.
        /// </summary>
        [EnumMember(Value = "Stopping")]
        Stopping,

        /// <summary>
        /// Park brake on, turn off the engine. We're done.
        /// </summary>
        [EnumMember(Value = "Stopped")]
        Stopped
    }
}
