using System;
using System.Text;

namespace NetCoreApiExtensions.Shared.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Unrolls the exception into a single string
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>System.String.</returns>
        public static string GetFullExceptionString(this Exception exception)
        {
            var exceptionDetails = new StringBuilder();

            exceptionDetails.AppendLine($"Message: {exception.Message}");
            exceptionDetails.AppendLine($"StackTrace:{exception.StackTrace}");

            if (exception.InnerException != null)
            {
                exceptionDetails.AppendLine();
                exceptionDetails.AppendLine();
                exceptionDetails.AppendLine("Inner Exception:");
                exceptionDetails.AppendLine(exception.InnerException.GetFullExceptionString());
            }

            return exceptionDetails.ToString();
        }

        /// <summary>
        /// Throws a StatusCodeException with the specified status code
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="errors"></param>
        /// <param name="keyedErrors"></param>
        /// <returns>StatusCodeException.</returns>
        public static StatusCodeException ThrowStatusCodeException(this Exception exception, HttpStatusCode statusCode,
            IEnumerable<string> errors = null, IEnumerable<IListItem<string, string>> keyedErrors = null)
        {
            var statusCodeException = new StatusCodeException(statusCode, exception.Message, exception.InnerException, errors, keyedErrors);
            throw statusCodeException;
        }
    }
}
