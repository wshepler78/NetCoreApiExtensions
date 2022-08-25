using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AuthorizationException : StatusCodeException
    {
        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.Forbidden;

        public AuthorizationException() : this(null)
        {
        }

        public AuthorizationException(string message) : base(ErrorStatusCode, message)
        {
        }

        public AuthorizationException(string message, Exception innerException) : base(ErrorStatusCode, message, innerException)
        {
        }

        public AuthorizationException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public AuthorizationException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message, innerException, errors, null)
        {
        }

        public AuthorizationException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, null, null, keyedErrors)
        {
        }

        public AuthorizationException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, innerException, null, keyedErrors)
        {
        }

        protected AuthorizationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
