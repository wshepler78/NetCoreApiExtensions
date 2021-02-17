using System;

namespace NetCoreApiExtensions.Shared.Requests
{
    public class PagedFilterRequest<T> : FilterRequest<T> where T : Enum
    {
        public int Page { get; set; }
        public int NumberPerPage { get; set; }
    }
}