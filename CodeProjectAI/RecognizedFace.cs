namespace CodeProjectAI
{
    public class RecognizedFace
    {
        public string? userid { get; set; }
        public float confidence { get; set; }
        public int y_min { get; set; }
        public int x_min { get; set; }
        public int y_max { get; set; }
        public int x_max { get; set; }
    }
}
