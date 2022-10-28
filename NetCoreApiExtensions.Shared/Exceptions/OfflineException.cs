using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class OfflineException : StatusCodeException
    {

        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.ServiceUnavailable;

        public OfflineException() : this(null)
        {
        }

        public OfflineException(string message) : base(ErrorStatusCode, message)
        {
        }

        public OfflineException(string message, Exception innerException) : base(ErrorStatusCode, message, innerException)
        {
        }
        public OfflineException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public OfflineException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message, innerException, errors, null)
        {
        }

        public OfflineException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, null, null, keyedErrors)
        {
        }

        public OfflineException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message, innerException, null, keyedErrors)
        {
        }

        protected OfflineException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
