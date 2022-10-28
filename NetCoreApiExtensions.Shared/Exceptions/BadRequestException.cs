using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class BadRequestException : StatusCodeException
    {
        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.BadRequest;
        public BadRequestException() : this(null)
        {
        }

        public BadRequestException(string message) : base(ErrorStatusCode, message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(ErrorStatusCode, message, innerException)
        {
        }

        public BadRequestException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public BadRequestException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message, innerException, errors, null)
        {
        }

        public BadRequestException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, null, null, keyedErrors)
        {
        }

        public BadRequestException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, innerException, null, keyedErrors)
        {
        }

        protected BadRequestException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
