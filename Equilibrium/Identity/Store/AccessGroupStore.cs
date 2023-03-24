using Equilibrium.Components.Communication;
using Equilibrium.Identity.Entities;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Identity.Store
{
    /// <summary>
    /// Default implementation of the AccessGroup Store.
    /// </summary>
    public class AccessGroupStore : AccessGroupStore<AccessGroup, IdentityContext>
    {
        public AccessGroupStore(IdentityContext ctx) : base(ctx) { }

        public override bool HasRecords => context.Users.Any();

        public override async Task<OperationResult> CreateAsync(AccessGroup resource, CancellationToken cancellationToken)
        {
            try
            {
                context.AccessGroups.Add(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success(resource);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public override async Task<OperationResult> DeleteAsync(AccessGroup resource, CancellationToken cancellationToken)
        {
            try
            {
                context.AccessGroups.Remove(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success();
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public override async Task<AccessGroup> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.AccessGroups.FindAsync(id, cancellationToken);
        }

        public override async Task<AccessGroup> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await context.AccessGroups.FirstOrDefaultAsync(u => u.Name == name);
        }

        public override IQueryable<AccessGroup> GetCollection(CancellationToken cancellationToken)
        {
            return context.AccessGroups.AsQueryable<AccessGroup>();
        }

        public override async Task<OperationResult> UpdateAsync(AccessGroup resource, CancellationToken cancellationToken)
        {
            try
            {
                context.AccessGroups.Update(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success(resource);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
    }

    public abstract class AccessGroupStore<TAccessGroup, TContext> :
        StoreBase<TContext>,
        IAccessGroupStore<TAccessGroup>
        where TAccessGroup : AccessGroup
        where TContext : DbContext
    {
        public AccessGroupStore(TContext ctx) : base(ctx) { }

        public abstract bool HasRecords { get; }

        public abstract Task<OperationResult> CreateAsync(TAccessGroup resource, CancellationToken cancellationToken);

        public abstract Task<OperationResult> DeleteAsync(TAccessGroup resource, CancellationToken cancellationToken);

        public abstract Task<TAccessGroup> FindByIdAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task<TAccessGroup> FindByNameAsync(string name, CancellationToken cancellationToken);

        public abstract IQueryable<TAccessGroup> GetCollection(CancellationToken cancellationToken);

        public abstract Task<OperationResult> UpdateAsync(TAccessGroup resource, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Defines the default contract for the AccessGroup base store.
    /// </summary>
    public interface IAccessGroupStore : IAccessGroupStore<AccessGroup> { }

    /// <summary>
    /// Defines a contract for the AccessGroup base store.
    /// </summary>
    /// <typeparam name="TAccessGroup">A concrete implementation of a class inheriting from <see cref="AccessGroup/>.</typeparam>
    /// <remarks>Inherit from this interface to add custom methods to the store.</remarks>
    public interface IAccessGroupStore<TAccessGroup> : IResourceStore<TAccessGroup> where TAccessGroup : AccessGroup
    {

    }
}
