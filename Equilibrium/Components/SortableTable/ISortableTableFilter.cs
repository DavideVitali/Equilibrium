using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Equilibrium.Components.SortableTable
{
    public interface ISortableTableFilter
    {
        /// <summary>
        /// Json DOM representing the fields selected as filter
        /// </summary>
        public string JsonDOMContainer { get; }

        public static Dictionary<object, List<object>> CreateFilterModel();
    }
}
