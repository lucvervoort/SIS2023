namespace CodeProjectAI
{
    /// <summary>
    /// The Response when requesting general info (eg logs) from one of the backend analysis modules
    /// </summary>
    public class ModuleResponse : SuccessResponse
    {
        public object? data { get; set; }
    }
}
