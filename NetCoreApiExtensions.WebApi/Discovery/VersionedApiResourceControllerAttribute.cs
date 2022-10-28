using System.Linq;

namespace NetCoreApiExtensions.WebApi.Discovery
{
    /// <summary>
    /// An API Controller decoration for building versioned routes
    /// </summary>
    /// <seealso cref="NetCoreApiExtensions.WebApi.Discovery.ApiResourceControllerAttribute" />
    public class VersionedApiResourceControllerAttribute : ApiResourceControllerAttribute
    {
        /// <summary>
        /// The default version template
        /// </summary>
        public static string DefaultVersionTemplate = "api/v{version:apiVersion}";

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionedApiResourceControllerAttribute"/> class.
        /// </summary>
        public VersionedApiResourceControllerAttribute() : this(true)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionedApiResourceControllerAttribute"/> class.
        /// </summary>
        /// <param name="includeController">if set to <c>true</c> [include controller].</param>
        public VersionedApiResourceControllerAttribute(bool includeController = true) : this(DefaultVersionTemplate, new string[0], includeController)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionedApiResourceControllerAttribute"/> class.
        /// </summary>
        /// <param name="rootResourceSegments">The root resource segments.</param>
        /// <param name="includeController">if set to <c>true</c> [include controller].</param>
        public VersionedApiResourceControllerAttribute(string[] rootResourceSegments, bool includeController = true) : this(DefaultVersionTemplate, rootResourceSegments, includeController)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionedApiResourceControllerAttribute"/> class.
        /// </summary>
        /// <param name="versionTemplate">The version template. if not supplied defaults to <see cref="DefaultVersionTemplate"/></param>
        /// <param name="rootResourceSegments">The root resource segments.</param>
        /// <param name="includeController">if set to <c>true</c> [include controller].</param>
        public VersionedApiResourceControllerAttribute(string versionTemplate, string[] rootResourceSegments, bool includeController = true)
            : base(string.IsNullOrWhiteSpace(versionTemplate) ? rootResourceSegments : rootResourceSegments.Prepend(versionTemplate).ToArray(), includeController)
        {
            VersionTemplate = versionTemplate;
        }

        /// <summary>
        /// Gets or sets the version template.
        /// </summary>
        public string VersionTemplate { get; set; }
    }
}