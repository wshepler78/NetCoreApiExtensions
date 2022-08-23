using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class ConflictException : StatusCodeException
    {
        public ConflictException() : this(null)
        {
        }

        public ConflictException(string message) : this(message, null, null)
        {
        }

        public ConflictException(string message, Exception innerException) : base(HttpStatusCode.Conflict, message, innerException)
        {
        }

        public ConflictException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public ConflictException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.Conflict, message, innerException, errors)
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
