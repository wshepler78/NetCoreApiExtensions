namespace NetCoreApiExtensions.Shared
{
    public class ListItem<T, TV> : IListItem<T, TV>
    {
        public T Key { get; set; }
        public TV Value { get; set; }
    }
}