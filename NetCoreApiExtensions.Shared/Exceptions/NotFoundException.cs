using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class NotFoundException : StatusCodeException
    {
        public NotFoundException() : this(null)
        {
        }

        public NotFoundException(string message) : this(message, null, null)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(HttpStatusCode.NotFound, message, innerException)
        {
        }

        public NotFoundException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public NotFoundException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.NotFound, message, innerException, errors)
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
