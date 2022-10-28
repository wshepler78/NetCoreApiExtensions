using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class NotFoundException : StatusCodeException
    {

        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.NotFound;
        public NotFoundException() : this(null)
        {
        }

        public NotFoundException(string message) : base(ErrorStatusCode, message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(ErrorStatusCode, message, innerException)
        {
        }

        public NotFoundException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public NotFoundException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message, innerException, errors, null)
        {
        }

        public NotFoundException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, null, null, keyedErrors)
        {
        }

        public NotFoundException(string message,Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, innerException, null, keyedErrors)
        {
        }

        protected NotFoundException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
