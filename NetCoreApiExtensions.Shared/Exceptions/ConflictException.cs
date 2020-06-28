using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class ConflictException : StatusCodeException
    {
        public ConflictException () : this(null)
        {
        }

        public ConflictException (string message) : this(message, null)
        {
        }

        public ConflictException (string message, Exception innerException) : base(HttpStatusCode.Conflict, message, innerException)
        {
        }

        protected ConflictException (
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
