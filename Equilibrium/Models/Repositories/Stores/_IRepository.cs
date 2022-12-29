using Equilibrium.Components.OperationResult;
using Equilibrium.Models.Repositories.Entities;
using System.Runtime.InteropServices;

namespace Equilibrium.Models.Repositories.Stores
{
    public interface IRepository<T> where T : IEntity
    {
        public OperationResult Create(T entity);
        public OperationResult Get(T entity);
        public OperationResult Update(T entity);
        public OperationResult Delete(T entity);
        public IQueryable<T> GetAll();
    }
}
