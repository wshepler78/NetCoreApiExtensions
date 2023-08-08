using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    [Serializable]
    public class StatusCodeException : Exception, IStatusCodeException
    {
        public HttpStatusCode StatusCode { get; }
        ICollection<string> IStatusCodeException.Errors => Errors;
        public List<string> Errors { get; }
        ICollection<IListItem<string, string>> IStatusCodeException.KeyedErrors => KeyedErrors;
        public List<IListItem<string, string>> KeyedErrors { get; }

        public StatusCodeException() : this(string.Empty)
        {
        }

        public StatusCodeException(string message) : this(message, null)
        {
        }

        public StatusCodeException(string message, Exception innerException) : this(HttpStatusCode.InternalServerError, message, innerException)
        {
        }

        public StatusCodeException(HttpStatusCode code) : this(code, string.Empty)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message) : this(code, message, null, null, null)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message, Exception innerException) : this(code, message, innerException, null, null)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message, IEnumerable<string> errors) : this(code, message, null, errors, null)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message, IEnumerable<IListItem<string, string>> keyedErrors) : this(code, message, null, null, keyedErrors)
        {
        }

        public StatusCodeException(HttpStatusCode code, string message, Exception innerException, IEnumerable<string> errors, IEnumerable<IListItem<string, string>> keyedErrors) : base(message, innerException)
        {
            KeyedErrors = keyedErrors != null ? keyedErrors.ToList() : new List<IListItem<string, string>>();
            Errors = errors != null ? errors.ToList() : new List<string>();
            StatusCode = code;
        }

        protected StatusCodeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
        
        /// <summary>
        /// Executes supplied function, and throws a <exception cref="StatusCodeException"></exception> status code exception created from the errorConverter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR">The type of the exception to map.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="errorConverter">The error converter.</param>
        /// <returns>T.</returns>
        public static async Task<T> ExecuteAndThrowStatusCodeException<T, TR>(Func<Task<T>> method, Func<TR, StatusCodeException> errorConverter) where TR: Exception
        {
            try
            {
                return await method.Invoke();
            }
            catch (TR e)
            {
                var statusCodeException = errorConverter.Invoke(e);
                throw statusCodeException;
            }
        }
    }
}
