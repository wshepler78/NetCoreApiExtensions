using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class StatusCodeException : Exception, IStatusCodeException
    {
        public HttpStatusCode StatusCode { get; }
        public List<string> Errors { get; }

        public StatusCodeException() : this(string.Empty)
        {
        }

        public StatusCodeException(string message) : this(message, null)
        {
        }

        public StatusCodeException(string message, Exception innerException) : this(HttpStatusCode.InternalServerError, message, innerException)
        {
        }

        public StatusCodeException(HttpStatusCode code) : this(code, string.Empty)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message) : this(code, message, null, null)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message, Exception innerException) : this(code, message, innerException, null)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message, IEnumerable<string> errors) : this(code, message, null, errors)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message, Exception innerException, IEnumerable<string> errors) : base(message, innerException)
        {
            Errors = errors != null ? errors.ToList() : new List<string>();
            StatusCode = code;
        }

        protected StatusCodeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
