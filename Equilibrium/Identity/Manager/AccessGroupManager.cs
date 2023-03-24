using Equilibrium.Components.Communication;
using Equilibrium.Identity.Entities;
using Equilibrium.Identity.Store;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Equilibrium.Identity.Manager
{
    /// <summary>
    /// Default implementation for the <see cref="AccessGroupManager{TAccessGroup, TStore, TContext}"/> base class.
    /// </summary>
    public sealed class AccessGroupManager : AccessGroupManager<AccessGroup, AccessGroupStore, IdentityContext>
    {
        public AccessGroupManager(AccessGroupStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken)
        {
        }

        public override bool HasRecords => store.HasRecords;

        public override async Task<OperationResult> CreateAsync(AccessGroup resource, CancellationToken cancellationToken)
        {
            return await store.CreateAsync(resource, cancellationToken);
        }

        public override async Task<OperationResult> DeleteAsync(AccessGroup resource, CancellationToken cancellationToken)
        {
            return await store.DeleteAsync(resource, cancellationToken);
        }

        public override async Task<AccessGroup> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await store.FindByIdAsync(id, cancellationToken);
        }

        public override async Task<AccessGroup> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await store.FindByNameAsync(name, cancellationToken);
        }

        public override IQueryable<AccessGroup> GetCollection(CancellationToken cancellationToken)
        {
            return store.GetCollection(cancellationToken);
        }

        public override async Task<OperationResult> UpdateAsync(AccessGroup resource, CancellationToken cancellationToken)
        {
            return await store.UpdateAsync(resource, cancellationToken);
        }
    }

    public abstract class AccessGroupManager<TAccessGroup, TStore, TContext> : ManagerBase<TStore, TContext>, IAccessGroupStore<TAccessGroup>
        where TAccessGroup : AccessGroup
        where TStore : StoreBase<TContext>
        where TContext : DbContext
    {
        public AccessGroupManager(TStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken) { }

        public abstract bool HasRecords { get; }

        public abstract Task<OperationResult> CreateAsync(TAccessGroup resource, CancellationToken cancellationToken);

        public abstract Task<OperationResult> DeleteAsync(TAccessGroup resource, CancellationToken cancellationToken);

        public abstract Task<TAccessGroup> FindByIdAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task<TAccessGroup> FindByNameAsync(string name, CancellationToken cancellationToken);

        public abstract IQueryable<TAccessGroup> GetCollection(CancellationToken cancellationToken);

        public abstract Task<OperationResult> UpdateAsync(TAccessGroup resource, CancellationToken cancellationToken);
    }
}
