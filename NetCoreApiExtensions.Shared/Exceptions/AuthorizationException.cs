using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AuthorizationException : StatusCodeException
    {
        public AuthorizationException () : this(null)
        {
        }

        public AuthorizationException (string message) : this(message, null)
        {
        }

        public AuthorizationException (string message, Exception innerException) : base(HttpStatusCode.Forbidden, message, innerException)
        {
        }

        protected AuthorizationException (
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
