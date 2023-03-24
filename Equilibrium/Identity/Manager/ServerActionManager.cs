using Equilibrium.Components.Communication;
using Equilibrium.Identity.Entities;
using Equilibrium.Identity.Store;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;

namespace Equilibrium.Identity.Manager
{
    /// <summary>
    /// Default implementation for the <see cref="AccessGroupManager{TAccessGroup, TStore, TContext}"/> base class.
    /// </summary>
    public sealed class ServerActionManager : ServerActionManager<ServerActionEntity, ServerActionEntityStore, IdentityContext>
    {
        public ServerActionManager(ServerActionEntityStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken)
        {
        }

        public override bool HasRecords => store.HasRecords;

        public override async Task<OperationResult> CreateAsync(ServerActionEntity resource, CancellationToken cancellationToken)
        {
            return await store.CreateAsync(resource, cancellationToken);
        }

        public override async Task<OperationResult> DeleteAsync(ServerActionEntity resource, CancellationToken cancellationToken)
        {
            return await store.DeleteAsync(resource, cancellationToken);
        }

        public override async Task<ServerActionEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await store.FindByIdAsync(id, cancellationToken);
        }

        public override async Task<ServerActionEntity> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await store.FindByNameAsync(name, cancellationToken);
        }

        public override IQueryable<ServerActionEntity> GetCollection(CancellationToken cancellationToken)
        {
            return store.GetCollection(cancellationToken);
        }

        public override async Task<OperationResult> UpdateAsync(ServerActionEntity resource, CancellationToken cancellationToken)
        {
            return await store.UpdateAsync(resource, cancellationToken);
        }
    }

    public abstract class ServerActionManager<TServerActionEntity, TStore, TContext> : ManagerBase<TStore, TContext>, IServerActionEntityStore<TServerActionEntity>
        where TServerActionEntity : ServerActionEntity
        where TStore : StoreBase<TContext>
        where TContext : DbContext
    {
        public ServerActionManager(TStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken) { }

        public abstract bool HasRecords { get; }

        public abstract Task<OperationResult> CreateAsync(TServerActionEntity resource, CancellationToken cancellationToken);

        public abstract Task<OperationResult> DeleteAsync(TServerActionEntity resource, CancellationToken cancellationToken);

        public abstract Task<TServerActionEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task<TServerActionEntity> FindByNameAsync(string name, CancellationToken cancellationToken);

        public abstract IQueryable<TServerActionEntity> GetCollection(CancellationToken cancellationToken);

        public abstract Task<OperationResult> UpdateAsync(TServerActionEntity resource, CancellationToken cancellationToken);
    }
}
