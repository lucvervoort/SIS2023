namespace CodeProjectAI
{
    public class NvidiaInfo : GpuInfo
    {
        public NvidiaInfo() : base()
        {
            HardwareVendor = "NVIDIA";
        }

        /// <summary>
        /// The CUDA version that the current driver is capable of using
        /// </summary> 
        public string? CudaVersionCapability { get; set; }

        /// <summary>
        /// The actual version of CUDA that's installed
        /// </summary>
        public string? CudaVersionInstalled { get; set; }

        public string? ComputeCapacity { get; internal set; }

        /// <summary>
        /// The string representation of this object
        /// </summary>
        /// <returns>A string object</returns>
        public override string Description
        {
            get
            {
                var info = base.Description
                         + $" CUDA: {CudaVersionInstalled} (max supported: {CudaVersionCapability})"
                         + " Compute: " + ComputeCapacity;

                return info;
            }
        }
    }
}
