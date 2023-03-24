using Equilibrium.Components.Communication;
using Equilibrium.Identity.Entities;
using Equilibrium.Identity.Store;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;

namespace Equilibrium.Identity.Manager
{
    /// <summary>
    /// Default implementation for the <see cref="UserManager{TStore, TContext}"/> base class.
    /// </summary>
    public sealed class UserManager : UserManager<User, UserStore, IdentityContext>
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

        public override async Task<User> FindInAccessGroupAsync(User user, AccessGroup accessGroup, CancellationToken cancellationToken, bool deepSearch = false)
        {
            return await store.FindInAccessGroupAsync(user, accessGroup, cancellationToken, deepSearch);
        }

        public override async Task<User> FindInAccessGroupsAsync(User user, IQueryable<AccessGroup> accessGroups, CancellationToken cancellationToken, bool deepSearch = false)
        {
            return await store.FindInAccessGroupsAsync(user, accessGroups, cancellationToken, deepSearch);
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
        public abstract Task<TUser> FindInAccessGroupAsync(TUser user, AccessGroup accessGroup, CancellationToken cancellationToken, bool deepSearch = false);
        public abstract Task<TUser> FindInAccessGroupsAsync(TUser user, IQueryable<AccessGroup> accessGroups, CancellationToken cancellationToken, bool deepSearch = false);
        public abstract IQueryable<TUser> GetCollection(CancellationToken cancellationToken);
        public abstract Task<OperationResult> UpdateAsync(TUser resource, CancellationToken cancellationToken);
    }
}
