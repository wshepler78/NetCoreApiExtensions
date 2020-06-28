using System.Collections.Generic;

namespace NetCoreApiExtensions.Shared
{
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int ResultsPerPage { get; set; }
        public ICollection<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
