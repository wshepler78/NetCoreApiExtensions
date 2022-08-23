using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class BadRequestException : StatusCodeException
    {
        public BadRequestException() : this(null)
        {
        }

        public BadRequestException(string message) : this(message, null, null)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(HttpStatusCode.BadRequest, message, innerException)
        {
        }
        public BadRequestException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public BadRequestException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.BadRequest, message, innerException, errors)
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
