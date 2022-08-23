using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AuthenticationException : StatusCodeException
    {
        public AuthenticationException() : this(null)
        {
        }

        public AuthenticationException(string message) : this(message, null, null)
        {
        }

        public AuthenticationException(string message, Exception innerException) : base(HttpStatusCode.Unauthorized, message, innerException)
        {
        }
        public AuthenticationException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public AuthenticationException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.Unauthorized, message, innerException, errors)
        {
        }

        protected AuthenticationException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
