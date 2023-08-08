using NetCoreApiExtensions.WebApi.Extensions;
using NetCoreApiExtensions.WebApi.Middleware.ExceptionHandling;

namespace NetCoreApiExtensions.WebApi.TestHarness;

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

        var swaggerEnvironments = new List<string> {"test", "QA"};

        var app = builder.BuildNetCoreApi("Convention Test Harness", enableSwaggerFor:swaggerEnvironments.ToArray());
        app.UseMiddleware<NetCoreApiExtensionsExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}


