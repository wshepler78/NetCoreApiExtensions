using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class ConflictException : StatusCodeException
    {
        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.Conflict;

        public ConflictException() : this(null)
        {
        }

        public ConflictException(string message) : base(ErrorStatusCode, message)
        {
        }

        public ConflictException(string message, Exception innerException) : base(ErrorStatusCode, message, innerException)
        {
        }

        public ConflictException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public ConflictException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message, innerException, errors, null)
        {
        }

        public ConflictException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, null, null, null, keyedErrors)
        {
        }

        public ConflictException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, null, innerException, null, keyedErrors)
        {
        }

        protected ConflictException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
