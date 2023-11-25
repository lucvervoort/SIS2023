namespace CodeProjectAI
{
    /// <summary>
    /// The Response for a Scene Detection request.
    /// </summary>
    public class DetectSceneResponse : SuccessResponse
    {
        /// <summary>
        /// Gets or sets the confidence level of the face detection from 0 to 1.
        /// </summary>
        public float confidence { get; set; }

        /// <summary>
        /// Gets or sets the name of the detected scene.
        /// </summary>
        public string? label { get; set; }
    }
}
