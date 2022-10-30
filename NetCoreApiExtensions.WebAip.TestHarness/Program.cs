using NetCoreApiExtensions.WebApi.Extensions;
using NetCoreApiExtensions.WebApi.Middleware.ExceptionHandling;

namespace NetCoreApiExtensions.WebAip.TestHarness;

/// <summary>
/// App Starting Class
/// </summary>
public class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.BuildNetCoreApi("Convention Test Harness");
        app.UseMiddleware<NetCoreApiExtensionsExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}


