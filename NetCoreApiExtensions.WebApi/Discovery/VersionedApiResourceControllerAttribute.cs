using System.Linq;

namespace NetCoreApiExtensions.WebApi.Discovery
{
    public class VersionedApiResourceControllerAttribute : ApiResourceControllerAttribute
    {
        public static string DefaultVersionTemplate = "api/v{version:apiVersion}";

        public VersionedApiResourceControllerAttribute() : this(true)
        {

        }

        public VersionedApiResourceControllerAttribute(bool includeController = true) : this(DefaultVersionTemplate, new string[0], includeController)
        {

        }

        public VersionedApiResourceControllerAttribute(string[] rootResourceSegments, bool includeController = true) : this(DefaultVersionTemplate, rootResourceSegments, includeController)
        {

        }

        public VersionedApiResourceControllerAttribute(string versionTemplate, string[] rootResourceSegments, bool includeController = true)
            : base(string.IsNullOrWhiteSpace(versionTemplate) ? rootResourceSegments : rootResourceSegments.Prepend(versionTemplate).ToArray(), includeController)
        {
            VersionTemplate = versionTemplate;
        }

        public string VersionTemplate { get; set; }
    }
}