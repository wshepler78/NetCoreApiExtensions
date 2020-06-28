using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class OfflineException : StatusCodeException
    {
        public OfflineException () : this(null)
        {
        }

        public OfflineException (string message) : this(message, null)
        {
        }

        public OfflineException (string message, Exception innerException) : base(HttpStatusCode.ServiceUnavailable, message, innerException)
        {
        }

        protected OfflineException (
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
