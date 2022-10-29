using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace NetCoreApiExtensions.WebApi.Discovery;


/// <summary>
/// Versioned API Controller.<br /><br />
///
/// creates the controller in the initial route `api/v{version:apiVersion}/[Controller]/&lt;aggregate of names[]&gt;<br /><br />
///
/// if used with NetCoreApiExtension convention configuration, apiVersion is supplied conventionally by folder:<br /><br />
///
/// <b>api/v1 Folder Structure</b> <br /><br />
/// 
/// - [v1_0] <br />
/// -- [Controllers]<br />
/// ---- MyController.cs<br /><br /><br />
///
/// Also supports "dashed" sub-versions: <br />
/// <b>api/v2-beta Folder Structure</b><br /><br />
///
/// - [v2_0-beta]<br />
/// -- [Controllers]<br />
/// ---- MyController.cs<br />
/// 
/// </summary>
/// <seealso cref="System.Attribute" />
/// <seealso cref="Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider" />
[AttributeUsage(AttributeTargets.Class)]
public class VersionedApiControllerAttribute : ApiControllerAttribute, IRouteTemplateProvider
{
    /// <summary>
    /// Instantiates a <see cref="VersionedApiControllerAttribute"/>
    /// </summary>
    /// <param name="rootResourceSegments"></param>
    public VersionedApiControllerAttribute(params string[] rootResourceSegments)
    {
        var pathSegments = rootResourceSegments != null ? rootResourceSegments.ToList() : new List<string>();
        pathSegments.Add("[Controller]");
        Name = string.Join('/', pathSegments);
        Template = $"api/v{{version:apiVersion}}/{Name}";
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public int? Order { get; set; }

    /// <inheritdoc />
    public string Template { get; set; }
}