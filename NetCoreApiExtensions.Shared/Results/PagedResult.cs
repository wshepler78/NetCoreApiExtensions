using System.Collections.Generic;

namespace NetCoreApiExtensions.Shared
{
    public class PagedResult<T>: IPagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int ResultsPerPage { get; set; }
        public ICollection<T> Data { get; set; }
        public long TotalCount { get; set; }
        public long TotalPages { get; set; }
    }
}
