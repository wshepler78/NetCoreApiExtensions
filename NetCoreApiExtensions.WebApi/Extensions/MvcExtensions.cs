using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreApiExtensions.WebApi.Extensions;

/// <summary>
/// NetCoreApiExtensions: MvC Extensions
/// </summary>
public static class MvcExtensions
{
    /// <summary>
    /// NetCoreApiExtensions: Adds the API versioning from the MVC Explorer.<br /><br />
    /// Adds controllers<br />
    /// Adds API Versioning<br />
    /// Configures System.Text.Json with camelcase and other default options.<br />
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="groupNameFormat">The API Version group name format.
    /// <remarks>
    /// For information about API version formatting, review <see cref="ApiVersionFormatProvider"/>
    /// as well as the <see cref="ApiVersion.ToString(string)"/> and <see cref="ApiVersion.ToString(string, IFormatProvider)"/>
    /// methods.
    /// </remarks>
    /// </param>
    public static IServiceCollection ConfigureVersionedApi(this IServiceCollection services, string groupNameFormat = "'v'VVV")
    {
        services.AddApiVersioning(
            options =>
            {
                options.Conventions.Add(new VersionByNamespaceConvention());
                options.ReportApiVersions = true;
            });
        services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = groupNameFormat;
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddControllers();

        services
            .AddControllers()
            .AddJsonOptions(NetCoreJsonSerializer.NetCoreJsonConfigurationAction);

        services.AddCors();

        return services;
    }
}