namespace CodeProjectAI
{
    /// <summary>
    /// The Response for a Detect Objects request.
    /// </summary>
    public class DetectObjectsResponse : SuccessResponse
    {
        /// <summary>
        /// Gets or sets the list of detected object predictions.
        /// </summary>
        public DetectedObject[]? predictions { get; set; }

        public int duration { get; set; } = 0;
    }
}
