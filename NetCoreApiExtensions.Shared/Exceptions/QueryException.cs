using System;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class QueryException : BadRequestException
    {
        public const string ErrorMessage = "The query could not be executed";

        public QueryException () : this(null)
        {
        }

        public QueryException(string message) : this(message, null)
        {
        }

        public QueryException (string message, Exception innerException) : base(message?.Length > 0? message : ErrorMessage, innerException)
        {
        }
    }
}
