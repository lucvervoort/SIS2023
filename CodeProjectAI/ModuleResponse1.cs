namespace CodeProjectAI
{
    /// <summary>
    /// The Response when requesting general info (eg logs) from one of the backend analysis modules
    /// </summary>
    public class ModuleResponse<T> : SuccessResponse
    {
        public T? data { get; set; }
    }
}
