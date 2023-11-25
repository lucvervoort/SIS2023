namespace CodeProjectAI
{
    public class RecognizeFacesResponse : SuccessResponse
    {
        public RecognizedFace[]? predictions { get; set; }
    }
}
