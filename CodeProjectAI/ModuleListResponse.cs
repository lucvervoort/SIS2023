namespace CodeProjectAI
{

    /// <summary>
    /// The Response when requesting the status of the backend analysis modules
    /// </summary>
    public class ModuleListResponse : SuccessResponse
    {
        public List<ModuleDescription>? modules { get; set; }
    }
}
