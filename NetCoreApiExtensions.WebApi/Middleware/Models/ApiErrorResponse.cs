namespace NetCoreApiExtensions.WebApi.Middleware.Models;

/// <summary>
/// Error detail wrapper
/// </summary>
public class ProcessedErrorDetails<T>
{
   /// <summary>
   /// Error Details to return to the client
   /// </summary>
   public T? Details { get; set; }
   /// <summary>
   /// Top-level error message to display
   /// </summary>
   public string Message { get; set; } = string.Empty;

}