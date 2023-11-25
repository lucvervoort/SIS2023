﻿using System.Text;

namespace CodeProjectAI
{
    /// <summary>
    /// Represents that status of a process that is running a module
    /// </summary>
    public class ProcessStatus
    {
        private int _processed;

        /// <summary>
        /// Gets or sets the module Id
        /// </summary>
        public string? ModuleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the queue this module is processing
        /// </summary>
        public string? Queue { get; set; }

        /// <summary>
        /// Gets or sets the module name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the module version
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// Gets or sets the UTC time the module was started
        /// </summary>
        public DateTime? Started { get; set; }

        /// <summary>
        /// Gets or sets the UTC time the module was last seen making a request to the backend queue
        /// </summary>
        public DateTime? LastSeen { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the module is running
        /// </summary>
        public ProcessStatusType Status { get; set; } = ProcessStatusType.Unknown;

        /// <summary>
        /// Gets the number of requests processed
        /// </summary>
        public int Processed { get => _processed; }

        /// <summary>
        /// Gets or sets the name of the hardware acceleration provider.
        /// </summary>
        public string? ExecutionProvider { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hardware type (CPU or GPU)
        /// </summary>
        public string? HardwareType { get; set; } = "CPU";

        /// <summary>
        /// Gets or sets a value indicating whether or not this detector can use the current GPU
        /// </summary>
        public bool? CanUseGPU { get; set; } = false;

        /// <summary>
        /// Gets or sets the human readable notes regarding how this process was installed.
        /// </summary>
        public string? InstallSummary { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the human readable notes regarding how this process was started.
        /// </summary>
        public string? StartupSummary { get; set; } = string.Empty;

        /// <summary>
        /// Increments the number of requests processed by 1.
        /// </summary>
        /// <returns>the incremented value</returns>
        public int IncrementProcessedCount() => Interlocked.Increment(ref _processed);

        /// <summary>
        /// Gets a human readable summary of the process running the given module
        /// </summary>
        public string Summary
        {
            get
            {
                StringBuilder summary = new StringBuilder();

                // summary.AppendLine($"Process '{Name}' (ID: {ModuleId})");
                string timezone = TimeZoneInfo.Local.StandardName;
                string format = "dd MMM yyyy h:mm:ss tt";
                string started = (Started is null) ? "Not seen"
                                : Started.Value.ToLocalTime().ToString(format) + " " + timezone;
                string lastSeen = (LastSeen is null) ? "Not seen"
                                : LastSeen.Value.ToLocalTime().ToString(format) + " " + timezone;

                summary.AppendLine($"Started:      {started}");
                summary.AppendLine($"LastSeen:     {lastSeen}");
                summary.AppendLine($"Status:       {Status}");
                summary.AppendLine($"Processed:    {Processed}");
                summary.AppendLine($"Provider:     {ExecutionProvider}");
                summary.AppendLine($"CanUseGPU:    {CanUseGPU}");
                summary.AppendLine($"HardwareType: {HardwareType}");

                return summary.ToString();
            }
        }
    }
}
