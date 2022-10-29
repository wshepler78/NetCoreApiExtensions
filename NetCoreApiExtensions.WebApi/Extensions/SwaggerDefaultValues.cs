using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NetCoreApiExtensions.WebApi.Extensions;

/// <summary>
/// Default Swagger Api Descriptions.
/// </summary>
/// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
public class SwaggerDefaultValues : IOperationFilter
{
    /// <summary>
    /// Applies the specified operation.
    /// </summary>
    /// <param name="operation">The operation.</param>
    /// <param name="context">The context.</param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var apiDescription = context.ApiDescription;
        operation.Deprecated |= apiDescription.IsDeprecated();
        if (operation.Parameters == null)
        {
            return;
        }
        foreach (var parameter in operation.Parameters)
        {
            var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
            parameter.Description ??= description.ModelMetadata?.Description;
            parameter.Required |= description.IsRequired;
        }
    }
}