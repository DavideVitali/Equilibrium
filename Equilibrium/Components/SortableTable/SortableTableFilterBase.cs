using Equilibrium.Models.Repositories.Entities;
using System.Text.Json;

namespace Equilibrium.Components.SortableTable
{
    public class SortableTableFilterBase : ISortableTableFilter<Employee>
    {
        Employee TargetEntity;
        string serializedTargetEntity;

        public SortableTableFilterBase(Employee targetEntity)
        {
            TargetEntity = targetEntity;
            serializedTargetEntity = JsonSerializer.Serialize(targetEntity);
        }

        public string SerializedTargetEntity => serializedTargetEntity;

        public Dictionary<string, IEnumerable<string>> FilterModel => throw new NotImplementedException();
    }
}
