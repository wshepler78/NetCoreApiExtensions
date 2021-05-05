using System.ComponentModel;

namespace NetCoreApiExtensions.Shared.Enumerations
{
    public enum SortDirection
    {
        None,
        [Description("Ascending")]
        Asc,
        [Description("Descending")]
        Desc
    }
}