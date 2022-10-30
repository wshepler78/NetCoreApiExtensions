using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NetCoreApiExtensions.Shared;
using NetCoreApiExtensions.Shared.Exceptions;
using NetCoreApiExtensions.Shared.Responses;
using NetCoreApiExtensions.WebApi.Extensions;
using NetCoreApiExtensions.WebApi.Middleware.Models;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace NetCoreApiExtensions.WebApi.Middleware.ExceptionHandling
{
    /// <summary>
    /// Middleware for handling exceptions with FluentValidation and NetCoreApiExtensions.Shared.Exceptions
    /// </summary>
    public class NetCoreApiExtensionsExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NetCoreApiExtensionsExceptionHandlingMiddleware> _logger;
        /// <summary>
        /// Initializes Middleware for handling exceptions with FluentValidation and NetCoreApiExtensions.Shared.Exceptions
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public NetCoreApiExtensionsExceptionHandlingMiddleware(RequestDelegate next, ILogger<NetCoreApiExtensionsExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Async handler for invoking the middleware
        /// </summary>
        /// <param name="httpContext"></param>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;

            var exceptionRoute = context.Request.Path;
            var statusCode = HttpStatusCode.InternalServerError;
            var errorMessage = exception.Message;

            object? errorResult;

            switch (exception)
            {
                case StatusCodeException ex:
                    statusCode = ex.StatusCode;

                    if (ex.KeyedErrors.Any())
                    {
                        var processedStatusCodeError = new ProcessedErrorDetails<IReadOnlyCollection<IListItem<string, string>>>
                        {
                            Details = ex.KeyedErrors,
                            Message = ex.Message
                        };

                        var statusError = ErrorResponse<ProcessedErrorDetails<IReadOnlyCollection<IListItem<string, string>>>>.Create(processedStatusCodeError);
                        errorResult = statusError;

                        _logger.LogWarning(ex, ex.Message, statusError.CorrelationId, exceptionRoute, errorResult);
                    }
                    else
                    {
                        var processedStatusCodeError = new ProcessedErrorDetails<IReadOnlyCollection<string>>
                        {
                            Details = ex.Errors.Any() ? ex.Errors : null,
                            Message = ex.Message
                        };

                        var statusError = ErrorResponse<ProcessedErrorDetails<IReadOnlyCollection<string>>>.Create(processedStatusCodeError);
                        errorResult = statusError;

                        _logger.LogWarning(ex, errorMessage, statusError.CorrelationId, exceptionRoute, errorResult);
                    }

                    break;

                case FluentValidation.ValidationException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    var processedValidationFailure = new ProcessedErrorDetails<IReadOnlyCollection<ValidationFailure>>
                    {
                        Message = errorMessage,
                        Details = ex.Errors.ToArray()
                    };

                    var validationErrorResult = ErrorResponse<ProcessedErrorDetails<IReadOnlyCollection<ValidationFailure>>>.Create(processedValidationFailure);
                    errorResult = validationErrorResult;
                    break;

                case ValidationException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    var processedValidationException = new ProcessedErrorDetails<ValidationResult>
                    {
                        Message = errorMessage,
                        Details = ex.ValidationResult
                    };

                    var validationExceptionResult = ErrorResponse<ProcessedErrorDetails<ValidationResult>>.Create(processedValidationException);
                    errorResult = validationExceptionResult;

                    break;
                default:
                    var defaultProcessedError = new ProcessedErrorDetails<string>
                    {
                        Message = errorMessage,
                        Details = TryGetBody(context)
                    };

                    var defaultStatusError = ErrorResponse<string>.Create("An Error occurred while processing the request");
                    errorResult = defaultStatusError;
                    _logger.LogError(exception, errorMessage, defaultStatusError.CorrelationId, exceptionRoute, defaultProcessedError);
                    break;
            }

            var result = NetCoreJsonSerializer.TrySerializeErrorResult(errorResult);

            response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        internal static string TryGetBody(HttpContext context)
        {
            string requestBody;
            try
            {
                context.Request.EnableBuffering();
                using StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true);

                requestBody = reader.ReadToEndAsync().Result;
            }
            catch (Exception ex)
            {
                requestBody = $"An Error Occurred processing the request body: {ex.Message}";
            }
            finally
            {
                context.Request.Body.Position = 0;
            }

            return requestBody;
        }


    }
}
