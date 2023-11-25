namespace CodeProjectAI
{
    /// <summary>
    /// Represents what we know about System (non GPU) memory
    /// </summary>
    public class MemoryProperties
    {
        public ulong Total { get; set; }
        public ulong Used { get; set; }
        public ulong Available { get; set; }
    };
}
