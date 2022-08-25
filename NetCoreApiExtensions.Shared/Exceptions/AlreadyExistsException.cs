using System;
using System.Collections.Generic;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AlreadyExistsException : ConflictException
    {
        public const string ErrorMessage = "Object already exists";

        public AlreadyExistsException() : this(null)
        {
        }

        public AlreadyExistsException(string message) : base(message)
        {

        }

        public AlreadyExistsException(string message, Exception innerException) : base(message?.Length > 0 ? message : ErrorMessage, innerException)
        {
        }

        public AlreadyExistsException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public AlreadyExistsException(string message, Exception innerException, IEnumerable<string> errors) : base(message?.Length > 0 ? message : ErrorMessage, innerException, errors)
        {
        }

        public AlreadyExistsException(string message, IEnumerable<IListItem<string, string>> keyedErrors) : base(message?.Length > 0 ? message : ErrorMessage, null, keyedErrors)
        {
        }

        public AlreadyExistsException(string message, Exception innerException, IEnumerable<IListItem<string, string>> keyedErrors) : base(message?.Length > 0 ? message : ErrorMessage, innerException, keyedErrors)
        {
        }
    }
}
