namespace Equilibrium.Components.SortableTable
{
    public class SortableTableFilter : ISortableTableFilter
    {
        public string JsonDOMContainer { get; }

        public Dictionary<object, List<object>> FilterModel { get; }
    }
}
