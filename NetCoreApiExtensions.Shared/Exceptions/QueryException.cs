using System;
using System.Collections.Generic;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class QueryException : BadRequestException
    {
        public const string ErrorMessage = "The query could not be executed";

        public QueryException() : this(null)
        {
        }

        public QueryException(string message) : this(message, null, null)
        {
        }

        public QueryException(string message, Exception innerException) : base(message?.Length > 0 ? message : ErrorMessage, innerException)
        {
        }

        public QueryException(string message, IEnumerable<string> errors) : this(message, null, errors)
        {
        }

        public QueryException(string message, Exception innerException, IEnumerable<string> errors) : base(message?.Length > 0 ? message : ErrorMessage, innerException, errors)
        {
        }
    }
}
