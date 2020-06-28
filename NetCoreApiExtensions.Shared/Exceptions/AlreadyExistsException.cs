using System;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class AlreadyExistsException : ConflictException
    {
        public const string ErrorMessage = "Object already exists";

        public AlreadyExistsException () : this(null)
        {
        }

        public AlreadyExistsException(string message) : this(message, null)
        {

        }

        public AlreadyExistsException (string message, Exception innerException) : base(message?.Length > 0 ? message : ErrorMessage, innerException)
        {
        }

    }
}
