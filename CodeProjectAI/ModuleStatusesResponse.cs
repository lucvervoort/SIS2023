namespace CodeProjectAI
{
    /// <summary>
    /// The Response when requesting the status of the backend modules
    /// </summary>
    public class ModuleStatusesResponse : SuccessResponse
    {
        public List<ProcessStatus>? statuses { get; set; }
    }
}
