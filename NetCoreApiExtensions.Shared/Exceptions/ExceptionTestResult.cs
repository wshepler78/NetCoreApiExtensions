namespace NetCoreApiExtensions.Shared.Exceptions
{
    public class ExceptionTestResult
    {
        public ExceptionDetails Content { get; set; }
        public string ContentType { get; } = "text/json";
        public int StatusCode { get; set; }
    }
}
