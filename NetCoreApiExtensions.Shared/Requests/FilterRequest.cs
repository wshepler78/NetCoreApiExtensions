using System;
using System.Collections.Generic;

namespace NetCoreApiExtensions.Shared.Requests
{
    public class FilterRequest<T> where T : Enum
    {
        public List<FieldSort<T>> OrderBy { get; set; } = new List<FieldSort<T>>();
    }
}