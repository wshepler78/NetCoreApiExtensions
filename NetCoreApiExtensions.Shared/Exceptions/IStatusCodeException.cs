using System.Net;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    public interface IStatusCodeException
    {
        HttpStatusCode StatusCode { get; }
    }
}
