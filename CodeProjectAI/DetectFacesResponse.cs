namespace CodeProjectAI
{

#pragma warning disable IDE1006 // Naming Styles

    /// <summary>
    /// The Response for a Face Detection Request.
    /// </summary>
    public class DetectFacesResponse : SuccessResponse
    {
        /// <summary>
        /// Gets or sets the array of Detected faces.  May be null or empty.
        /// </summary>
        public DetectedFace[]? predictions { get; set; }
    }
#pragma warning restore IDE1006 // Naming Styles
}
