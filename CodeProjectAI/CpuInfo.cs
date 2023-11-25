namespace CodeProjectAI
{
    /// <summary>
    /// Represents the properties of a single CPU
    /// </summary>
    public class CpuInfo
    {
        public string? Name { get; set; }
        public string? HardwareVendor { get; set; }
        public uint NumberOfCores { get; set; }
        public uint LogicalProcessors { get; set; }
    };
}
