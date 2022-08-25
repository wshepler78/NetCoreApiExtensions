using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AuthenticationException : StatusCodeException
    {
        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.Unauthorized;

        public AuthenticationException() : this(null)
        {
        }

        public AuthenticationException(string message) : base(ErrorStatusCode, message)
        {
        }

        public AuthenticationException(string message, Exception innerException) : base(ErrorStatusCode, message, innerException)
        {
        }
        public AuthenticationException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public AuthenticationException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message, innerException, errors, null)
        {
        }

        public AuthenticationException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, null, null, keyedErrors)
        {
        }
        public AuthenticationException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, innerException, null, keyedErrors)
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
