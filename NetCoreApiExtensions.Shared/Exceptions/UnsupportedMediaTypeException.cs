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
        public static HttpStatusCode ErrorStatusCode = HttpStatusCode.UnsupportedMediaType;

        public UnsupportedMediaTypeException() : this(null)
        {
        }

        public UnsupportedMediaTypeException(string message) : base(ErrorStatusCode, message, null, null, null)
        {
        }

        public UnsupportedMediaTypeException(string message, Exception innerException) : base(ErrorStatusCode, message?.Length > 0 ? message : ErrorMessage, innerException)
        {
        }

        public UnsupportedMediaTypeException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public UnsupportedMediaTypeException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : this(message, null, keyedErrors)
        {
        }

        public UnsupportedMediaTypeException(string message, Exception innerException, IEnumerable<string> errors) : base(ErrorStatusCode, message?.Length > 0 ? message : ErrorMessage, innerException, errors, null)
        {
        }

        public UnsupportedMediaTypeException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(ErrorStatusCode, message?.Length > 0 ? message : ErrorMessage, innerException, null, keyedErrors)
        {
        }

        protected UnsupportedMediaTypeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
