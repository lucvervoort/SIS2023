using System.Text;

namespace CodeProjectAI
{
    public class GpuInfo
    {
        /// <summary>
        /// Gets or sets the name of the card
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the card's vendor
        /// </summary>
        public string? HardwareVendor { get; set; }

        /// <summary>
        /// Gets or sets the driver version string
        /// </summary>
        public string? DriverVersion { get; set; }

        /// <summary>
        /// Gets or sets GPU utlisation as a percentage between 0 and 100
        /// </summary>
        public int Utilization { get; set; }

        /// <summary>
        /// Gets or sets the total memory used in bytes
        /// </summary>
        public ulong MemoryUsed { get; set; }

        /// <summary>
        /// Gets or sets the total card memory in bytes
        /// </summary>
        public ulong TotalMemory { get; set; }

        /// <summary>
        /// The string representation of this object
        /// </summary>
        /// <returns>A string object</returns>
        public virtual string Description
        {
            get
            {
                var info = new StringBuilder();
                info.Append(Name);

                if (TotalMemory > 0)
                    info.Append($" ({SystemInfo.FormatSizeBytes(TotalMemory, 0)})");

                if (!string.IsNullOrWhiteSpace(HardwareVendor))
                    info.Append($" ({HardwareVendor})");

                if (!string.IsNullOrWhiteSpace(DriverVersion))
                    info.Append($" Driver: {DriverVersion}");

                return info.ToString();
            }
        }
    }
}
