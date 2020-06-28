using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class BadRequestException : StatusCodeException
    {
        public BadRequestException () : this(null)
        {
        }

        public BadRequestException (string message) : this(message, null)
        {
        }

        public BadRequestException (string message, Exception innerException) : base(HttpStatusCode.BadRequest, message, innerException)
        {
        }

        protected BadRequestException (
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
