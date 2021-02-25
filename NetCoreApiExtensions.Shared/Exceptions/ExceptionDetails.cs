using System;
using System.Text.Json.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    public class ExceptionDetails
    {
        public string Message => Exception?.Message;

        public string StackTrace => IncludeExceptionDetails ? Exception?.StackTrace : null;

        public string Source => IncludeExceptionDetails ? Exception?.Source : null;

        [JsonIgnore]
        public Exception Exception { get; set; }

        public ExceptionDetailsRequest RequestContext { get; set; }

        public DateTime ExceptionTime { get; } = DateTime.Now;

        public Guid ErrorId { get; } = Guid.NewGuid();

        public bool IncludeExceptionDetails { get; private set; }

        public static ExceptionDetails Create(Exception exception, ExceptionDetailsRequest request = null, bool includeExceptionDetails = false)
        {
            return new ExceptionDetails
                   {
                       Exception = exception,
                       RequestContext = request,
                       IncludeExceptionDetails = includeExceptionDetails
                   };
        }
    }


}
