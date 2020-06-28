using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class StatusCodeException : Exception, IStatusCodeException
    {
        public HttpStatusCode StatusCode { get; }

        public StatusCodeException() : this(string.Empty)
        {
        }

        public StatusCodeException (string message) : this(message, null)
        {
        }
        
        public StatusCodeException (string message, Exception innerException) : this(HttpStatusCode.InternalServerError, message, innerException)
        {
        }

        public StatusCodeException (HttpStatusCode code): this(code, string.Empty)
        {
        }

        public StatusCodeException (HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        public StatusCodeException (HttpStatusCode code, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = code;
        }

        protected StatusCodeException (
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
