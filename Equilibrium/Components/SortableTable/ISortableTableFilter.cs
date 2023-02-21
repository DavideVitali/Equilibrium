using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Equilibrium.Components.SortableTable
{
    /// <summary>
    /// Defines a contract for a SortableTable filter that automatically creates a model
    /// based on the <see cref="TTargetEntity"/> instance.
    /// </summary>
    /// <typeparam name="TTargetEntity">An instance of the Entity that will hold the filter keys and values</typeparam>
    public interface ISortableTableFilter<TTargetEntity> where TTargetEntity : class, new()
    {
        /// <summary>
        /// Json DOM representing the fields selected as filter
        /// </summary>
        public string SerializedTargetEntity { get; }

        Dictionary<string, IEnumerable<string>> FilterModel { get; }

        //public static Dictionary<object, List<object>> CreateFilterModel();
    }
}
