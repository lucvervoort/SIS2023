namespace CodeProjectAI
{
    /// <summary>
    /// The Response for a Face Match request.
    /// </summary>
    public class MatchFacesResponse : SuccessResponse
    {
        /// <summary>
        /// Gets or sets the Similarity of the two faces from 0 to 1.
        /// </summary>
        public float similarity { get; set; }
    }
}
