using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class NotFoundException : StatusCodeException
    {
        public NotFoundException ():this(null)
        {
        }

        public NotFoundException (string message): this(message, null)
        {
        }

        public NotFoundException (string message, Exception innerException): base(HttpStatusCode.NotFound, message, innerException)
        {
        }

        protected NotFoundException (
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
