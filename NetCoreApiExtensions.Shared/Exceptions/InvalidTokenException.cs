using System;
using System.Collections.Generic;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class InvalidTokenException : BadRequestException
    {
        public const string ErrorMessage = "The supplied token is invalid";

        public InvalidTokenException() : this(null)
        {
        }

        public InvalidTokenException(string message) : this(message, null, null)
        {

        }

        public InvalidTokenException(string message, Exception innerException) : base(message?.Length > 0 ? message : ErrorMessage, innerException)
        {
        }

        public InvalidTokenException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public InvalidTokenException(string message, Exception innerException, IEnumerable<string> errors) : base(message?.Length > 0 ? message : ErrorMessage, innerException, errors)
        {
        }

        public InvalidTokenException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(message, keyedErrors)
        {
        }
    }
}
