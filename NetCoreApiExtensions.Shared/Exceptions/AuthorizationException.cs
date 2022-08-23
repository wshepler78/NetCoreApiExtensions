using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AuthorizationException : StatusCodeException
    {
        public AuthorizationException() : this(null)
        {
        }

        public AuthorizationException(string message) : this(message, null, null)
        {
        }

        public AuthorizationException(string message, Exception innerException) : base(HttpStatusCode.Forbidden, message, innerException)
        {
        }
        public AuthorizationException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public AuthorizationException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.Forbidden, message, innerException, errors)
        {
        }
        protected AuthorizationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
