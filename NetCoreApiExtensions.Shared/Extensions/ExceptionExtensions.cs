using System;
using System.Text;

namespace NetCoreApiExtensions.Shared.Extensions
{
    public static class ExceptionExtensions
    {
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
    }
}