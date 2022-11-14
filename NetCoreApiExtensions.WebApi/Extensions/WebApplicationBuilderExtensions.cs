using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Hosting;

namespace NetCoreApiExtensions.WebApi.Extensions;

/// <summary>
/// NetCoreApiExtensions: Extensions for WebApplicationBuilder
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// NetCoreApiExtensions: creates a <seealso cref="WebApplication" /> and initializes the the API
    /// Calls:
    /// <seealso cref="SwaggerExtensions.ConfigureVersionedSwaggerApi" />
    /// builder.Build()
    /// <seealso cref="SwaggerExtensions.AddSwaggerByConventionToApplication" /> when in development environment
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="apiTitle">The API title.</param>
    /// <param name="groupNameFormat">The group name format.<br />
    /// For information about API version formatting, review <see cref="ApiVersionFormatProvider" />
    /// as well as the <see cref="ApiVersion.ToString(string)" /> and <see cref="ApiVersion.ToString(string, IFormatProvider)" />
    /// methods.</param>
    /// <param name="enableSwaggerFor">Environments to enable swagger UI for. (Development is always enabled)</param>
    /// <returns>
    ///   <see cref="WebApplication" /> configured for Convention-based versioning
    /// </returns>
    public static WebApplication BuildNetCoreApi(this WebApplicationBuilder builder, string apiTitle, string groupNameFormat = "'v'VVV", params string[] enableSwaggerFor)
    {
        apiTitle = $"{apiTitle} [{builder.Environment.EnvironmentName}]";
        builder.Services.ConfigureVersionedSwaggerApi(apiTitle, groupNameFormat);

        var app = builder.Build();

        if (app.Environment.IsDevelopment() || enableSwaggerFor.Any(s=> s.Equals(app.Environment.EnvironmentName, StringComparison.InvariantCultureIgnoreCase)))
        {
            app.AddSwaggerByConventionToApplication();
        }

        return app;
    }
}