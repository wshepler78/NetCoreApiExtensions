using System;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class InvalidTokenException : BadRequestException
    {
        public const string ErrorMessage = "The supplied token is invalid";

        public InvalidTokenException (): this(null)
        {
        }

        public InvalidTokenException(string message) : this(message, null)
        {

        }

        public InvalidTokenException (string message, Exception innerException): base(message?.Length > 0? message:ErrorMessage, innerException)
        {
        }
    }
}
