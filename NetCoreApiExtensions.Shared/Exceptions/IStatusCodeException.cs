using System.Collections.Generic;
using System.Net;

namespace NetCoreApiExtensions.Shared.Exceptions
{
    public interface IStatusCodeException
    {
        HttpStatusCode StatusCode { get; }
        ICollection<string> Errors { get; }
        ICollection<IListItem<string, string>> KeyedErrors { get; }
    }
}
