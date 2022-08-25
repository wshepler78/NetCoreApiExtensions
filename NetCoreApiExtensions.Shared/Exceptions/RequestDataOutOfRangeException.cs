using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class RequestDataOutOfRangeException : StatusCodeException
    {

        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.RequestedRangeNotSatisfiable;

        public RequestDataOutOfRangeException() : this(null)
        {
        }

        public RequestDataOutOfRangeException(string message) : base(ErrorStatusCode, message)
        {
        }

        public RequestDataOutOfRangeException(string message, Exception innerException) : base(ErrorStatusCode, message, innerException)
        {
        }

        public RequestDataOutOfRangeException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }
        public RequestDataOutOfRangeException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : this(message, null, keyedErrors)
        {
        }

        public RequestDataOutOfRangeException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message, innerException, errors, null)
        {
        }

        public RequestDataOutOfRangeException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, innerException, null, keyedErrors)
        {
        }

        protected RequestDataOutOfRangeException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

    }
}
