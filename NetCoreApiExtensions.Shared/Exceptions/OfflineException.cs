using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class OfflineException : StatusCodeException
    {
        public OfflineException() : this(null)
        {
        }

        public OfflineException(string message) : this(message, null, null)
        {
        }

        public OfflineException(string message, Exception innerException) : base(HttpStatusCode.ServiceUnavailable, message, innerException)
        {
        }
        public OfflineException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public OfflineException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.ServiceUnavailable, message, innerException, errors)
        {
        }

        protected OfflineException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
