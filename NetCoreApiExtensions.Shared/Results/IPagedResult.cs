using System.Collections.Generic;

namespace NetCoreApiExtensions.Shared
{
    public interface IPagedResult<T>
    {
        int CurrentPage { get; }
        int ResultsPerPage { get; }
        ICollection<T> Data { get; }
        long TotalCount { get; }
        long TotalPages { get; }
    }
}