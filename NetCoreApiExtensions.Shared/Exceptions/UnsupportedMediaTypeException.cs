using System;
using System.Net;
using System.Runtime.Serialization;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class UnsupportedMediaTypeException : StatusCodeException
    {
        public static string ErrorMessage = "Unsupported Media Type";

        public UnsupportedMediaTypeException () : this(null)
        {
        }

        public UnsupportedMediaTypeException (string message) : this(message, null)
        {
        }

        public UnsupportedMediaTypeException (string message, Exception innerException) : base(HttpStatusCode.UnsupportedMediaType, message?.Length > 0 ? message : ErrorMessage, innerException)
        {
        }

        protected UnsupportedMediaTypeException (
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}
