using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NetCoreApiExtensions.WebApi.Extensions;

/// <summary>
/// NetCoreApiExtensions: SwaggerGen Options
/// </summary>
public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{

    private readonly IApiVersionDescriptionProvider _provider;

    /// <summary>
    /// Gets or sets the title for your swagger API
    /// </summary>
    public static string Title { get; set; } = string.Empty;

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = Title,
            Version = description.ApiVersion.ToString()
        };
        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }
        return info;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
    /// </summary>
    /// <param name="provider">The provider.</param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    /// <summary>
    /// Invoked to configure a <see cref="SwaggerGenOptions"/> instance.
    ///
    /// Will attempt to add swagger documentation from xml files in the executing folder
    /// </summary>
    /// <param name="options">The options instance to configure.</param>
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            try
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
            catch (Exception)
            {
            }
        }

        var executingFile = new FileInfo(Assembly.GetExecutingAssembly().Location);

        if (executingFile.DirectoryName == null) return;

        var xmlFiles = System.IO.Directory.GetFiles(executingFile.DirectoryName, "*.xml");

        foreach (var xmlFile in xmlFiles)
            options.IncludeXmlComments($"{xmlFile}");
    }
}