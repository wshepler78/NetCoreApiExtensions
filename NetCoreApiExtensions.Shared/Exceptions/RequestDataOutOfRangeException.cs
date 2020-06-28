using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class RequestDataOutOfRangeException : StatusCodeException
    {
        public RequestDataOutOfRangeException ():this(null)
        {
        }

        public RequestDataOutOfRangeException (string message): this(message, null)
        {
        }

        public RequestDataOutOfRangeException (string message, Exception innerException): base(HttpStatusCode.RequestedRangeNotSatisfiable, message, innerException)
        {
        }

        protected RequestDataOutOfRangeException (
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
