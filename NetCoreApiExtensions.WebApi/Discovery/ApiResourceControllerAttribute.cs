using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace NetCoreApiExtensions.WebApi.Discovery
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider" />
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiResourceControllerAttribute : ApiControllerAttribute, IRouteTemplateProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResourceControllerAttribute"/> class.
        /// </summary>
        public ApiResourceControllerAttribute() : this(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResourceControllerAttribute"/> class.
        /// </summary>
        /// <param name="includeController">if set to <c>true</c> [include controller].</param>
        public ApiResourceControllerAttribute(bool includeController = true) : this(new string[0], includeController)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResourceControllerAttribute"/> class.
        /// </summary>
        /// <param name="rootResourceSegments">The root resource segments.</param>
        /// <param name="includeController">if set to <c>true</c> [include controller].</param>
        public ApiResourceControllerAttribute(string[] rootResourceSegments, bool includeController = true)
        {
            var resourceSegments = rootResourceSegments != null ? rootResourceSegments.ToList() : new List<string>();

            var pathSegments = new List<string>();

            resourceSegments.ForEach(resourceSegment =>
            {
                resourceSegment = $"{resourceSegment}";
                resourceSegment = resourceSegment.Trim();
                resourceSegment = resourceSegment.TrimStart('/');
                resourceSegment = resourceSegment.TrimEnd('/');

                if (!string.IsNullOrWhiteSpace(resourceSegment))
                {
                    pathSegments.Add(resourceSegment);
                }

            });

            if (includeController)
            {
                pathSegments.Add("[Controller]");
            }

            Name = string.Join('/', pathSegments);
            Template = Name;
        }
        
        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public int? Order { get; set; }

        /// <inheritdoc/>
        public string Template { get; set; }

    }
}
