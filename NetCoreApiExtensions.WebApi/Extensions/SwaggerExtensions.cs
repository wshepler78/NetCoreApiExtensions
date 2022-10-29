using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NetCoreApiExtensions.WebApi.Extensions;

/// <summary>
/// NetCoreApiExtensions Extensions for Swagger
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// NetCoreApiExtensions: Configures the MVC versioned swagger API.<br /><br />
    /// calls:<br />
    /// <seealso cref="AddSwaggerDocumentation" /><br />
    /// <seealso cref="ConfigureVersionedSwaggerApi"/> with groupNameFormat parameter <br />
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="apiTitle">The title of the API used by Swagger</param>
    /// <param name="groupNameFormat">The group name format.<br />
    /// For information about API version formatting, review <see cref="ApiVersionFormatProvider"/>
    /// as well as the <see cref="ApiVersion.ToString(string)"/> and <see cref="ApiVersion.ToString(string, IFormatProvider)"/>
    /// methods.
    /// </param>
    /// <returns></returns>
    public static IServiceCollection ConfigureVersionedSwaggerApi(this IServiceCollection services, string apiTitle, string groupNameFormat = "'v'VVV")
    {
        services.AddEndpointsApiExplorer();
        services.ConfigureVersionedApi(groupNameFormat);
        services.AddSwaggerDocumentation(apiTitle);

        return services;
    }


    /// <summary>
    /// NetCoreApiExtensions: Adds the swagger documentation.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="apiTitle">The title of the API used by Swagger</param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string apiTitle)
    {
        ConfigureSwaggerOptions.Title = apiTitle;
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            options.OperationFilter<SwaggerDefaultValues>();
        });
        return services;
    }

    /// <summary>
    /// NetCoreApiExtensions: Adds Swagger definitions by convention from MVC API Explorer
    /// </summary>
    /// <param name="app">The application.</param>
    /// <returns></returns>
    public static IApplicationBuilder AddSwaggerByConventionToApplication(this WebApplication app)//(this IApplicationBuilder app)
    {
        var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

        app.UseSwagger(swaggerOptions =>
        {
            swaggerOptions.PreSerializeFilters.Add((document, request) =>
            {
                var newPaths = new OpenApiPaths();
                foreach (var (key, value) in document.Paths)
                {
                    var keyParts = key.Split('/');

                    for (var index = 0; index < keyParts.Length; index++)
                    {
                        var keyPart = keyParts[index];

                        if (string.IsNullOrWhiteSpace(keyPart))
                        {
                            continue;
                        }

                        var newKeyPart = keyPart[..1].ToLowerInvariant();

                        if (keyPart.Length > 1)
                        {
                            newKeyPart += keyPart[1..];
                        }

                        keyParts[index] = newKeyPart;
                    }

                    var newKey = string.Join('/', keyParts);
                    newPaths.Add(newKey, value);
                }

                document.Paths = newPaths;
            });
        });

        app.UseSwaggerUI(options =>
            {
                if (provider == null) return;

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToLowerInvariant());
                }
            }
        );

        return app;
    }
}