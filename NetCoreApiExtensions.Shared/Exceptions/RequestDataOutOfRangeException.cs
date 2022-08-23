using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class RequestDataOutOfRangeException : StatusCodeException
    {
        public RequestDataOutOfRangeException() : this(null)
        {
        }

        public RequestDataOutOfRangeException(string message) : this(message, null, null)
        {
        }

        public RequestDataOutOfRangeException(string message, Exception innerException) : base(HttpStatusCode.RequestedRangeNotSatisfiable, message, innerException)
        {
        }
        public RequestDataOutOfRangeException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public RequestDataOutOfRangeException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.RequestedRangeNotSatisfiable, message, innerException, errors)
        {
        }

        protected RequestDataOutOfRangeException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
