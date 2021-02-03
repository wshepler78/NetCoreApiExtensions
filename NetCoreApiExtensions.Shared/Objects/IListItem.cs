namespace NetCoreApiExtensions.Shared
{
    public interface IListItem<T, TV>
    {
        T Key { get; set; }
        TV Value { get; set; }
    }
}