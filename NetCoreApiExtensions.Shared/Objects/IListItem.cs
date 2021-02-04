namespace NetCoreApiExtensions.Shared
{
    public interface IListItem<out T, out TV>
    {
        T Key { get; }
        TV Value { get; }
    }
}