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

namespace Equilibrium.Identity.Manager
{
    /// <summary>
    /// Default implementation for the <see cref="UserManager{TStore, TContext}"/> base class.
    /// </summary>
    public sealed class UserManager : UserManager<UserStore, DbContext>
    {
        public UserManager(UserStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken)
        {
        }

        public override bool HasRecords => store.HasRecords;

        public override async Task<OperationResult> CreateAsync(User resource, CancellationToken cancellationToken)
        {
            return await store.CreateAsync(resource, cancellationToken);
        }

        public override async Task<OperationResult> DeleteAsync(User resource, CancellationToken cancellationToken)
        {
            return await store.DeleteAsync(resource, cancellationToken);
        }

        public override async Task<User> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await store.FindByIdAsync(id, cancellationToken);
        }

        public override async Task<User> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await store.FindByNameAsync(name, cancellationToken);
        }

        public override IQueryable<User> GetCollection(CancellationToken cancellationToken)
        {
            return store.GetCollection(cancellationToken);
        }

        public override async Task<OperationResult> UpdateAsync(User resource, CancellationToken cancellationToken)
        {
            return await store.UpdateAsync(resource, cancellationToken);
        }
    }

    public abstract class UserManager<TStore, TContext> : ManagerBase<TStore, TContext>, IUserStore<User>
        where TStore : StoreBase<TContext>
        where TContext : DbContext
    {
        public UserManager(TStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken) { }

        public abstract bool HasRecords { get; }

        public abstract Task<OperationResult> CreateAsync(User resource, CancellationToken cancellationToken);

        public abstract Task<OperationResult> DeleteAsync(User resource, CancellationToken cancellationToken);

        public abstract Task<User> FindByIdAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task<User> FindByNameAsync(string name, CancellationToken cancellationToken);

        public abstract IQueryable<User> GetCollection(CancellationToken cancellationToken);

        public abstract Task<OperationResult> UpdateAsync(User resource, CancellationToken cancellationToken);
    }

    public abstract class UserManager<TUser, TStore, TContext> : ManagerBase<TStore, TContext>, IUserStore<TUser>
        where TUser : User
        where TStore : StoreBase<TContext>
        where TContext : DbContext
    {
        public UserManager(TStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken) { }

        public abstract bool HasRecords { get; }

        public abstract Task<OperationResult> CreateAsync(TUser resource, CancellationToken cancellationToken);

        public abstract Task<OperationResult> DeleteAsync(TUser resource, CancellationToken cancellationToken);

        public abstract Task<TUser> FindByIdAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task<TUser> FindByNameAsync(string name, CancellationToken cancellationToken);

        public abstract IQueryable<TUser> GetCollection(CancellationToken cancellationToken);

        public abstract Task<OperationResult> UpdateAsync(TUser resource, CancellationToken cancellationToken);
    }
}
