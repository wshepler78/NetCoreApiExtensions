using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class UnsupportedMediaTypeException : StatusCodeException
    {
        public static string ErrorMessage = "Unsupported Media Type";

        public UnsupportedMediaTypeException() : this(null)
        {
        }

        public UnsupportedMediaTypeException(string message) : this(message, null, null)
        {
        }

        public UnsupportedMediaTypeException(string message, Exception innerException) : base(HttpStatusCode.UnsupportedMediaType, message?.Length > 0 ? message : ErrorMessage, innerException)
        {
        }
        public UnsupportedMediaTypeException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public UnsupportedMediaTypeException(string message, Exception innerException, IEnumerable<string> errors) : base(HttpStatusCode.UnsupportedMediaType, message?.Length > 0 ? message : ErrorMessage, innerException, errors)
        {
        }

        protected UnsupportedMediaTypeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
