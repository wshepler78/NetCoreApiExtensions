namespace NetCoreApiExtensions.Shared.Exceptions
{
    public class ExceptionDetailsRequest
    {
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }

    }
}
