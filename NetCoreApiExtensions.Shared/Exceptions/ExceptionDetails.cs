using System;
using System.Text.Json.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    public class ExceptionDetails
    {
        public string Message => Exception?.Message;
        [JsonIgnore]
        public Exception Exception { get; set; }
        public ExceptionDetailsRequest RequestContext { get; set; }
        public DateTime ExceptionTime { get; } = DateTime.Now;
        public Guid ErrorId { get; } = Guid.NewGuid();

        public static ExceptionDetails Create(Exception exception)
        {
            return new ExceptionDetails
                   {
                       Exception = exception,
                       RequestContext = null
                   };
        }

        public static ExceptionDetails Create(Exception exception, ExceptionDetailsRequest request)
        {
            return new ExceptionDetails
                   {
                       Exception = exception,
                       RequestContext = request
                   };
        }
    }


}
