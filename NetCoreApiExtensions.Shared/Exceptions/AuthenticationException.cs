using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AuthenticationException : StatusCodeException
    {
        public AuthenticationException () : this(null)
        {
        }

        public AuthenticationException (string message) : this(message, null)
        {
        }

        public AuthenticationException (string message, Exception innerException) : base(HttpStatusCode.Unauthorized, message, innerException)
        {
        }

        protected AuthenticationException (
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
