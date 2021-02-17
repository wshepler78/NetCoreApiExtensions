using System;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.Shared.Requests
{
    public class FieldSort<T> where T: Enum
    {
        public T Key { get; set; }
        public SortDirection Value { get; set; }
    }
}