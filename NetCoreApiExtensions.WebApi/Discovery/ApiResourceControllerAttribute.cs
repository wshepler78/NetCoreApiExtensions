using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Routing;

namespace NetCoreApiExtensions.WebApi.Discovery
{
    public class ApiResourceControllerAttribute : Attribute, IRouteTemplateProvider
    {
        public ApiResourceControllerAttribute() : this(true)
        {
        }

        public ApiResourceControllerAttribute(bool includeController = true) : this(new string[0], includeController)
        {
        }
        
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

        public string Name { get; }
        public int? Order { get; set; }
        public string Template { get; set; }

    }
}
