using Equilibrium.Components.Communication;
using Equilibrium.Identity.Entities;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Equilibrium.Identity.Store
{
    /// <summary>
    /// Default implementation of the User Store.
    /// </summary>
    public class UserStore : UserStore<User, IdentityContext>
    {
        public UserStore(IdentityContext ctx) : base(ctx) { }

        public override bool HasRecords => context.Users.Any();

        public override async Task<OperationResult> CreateAsync(User resource, CancellationToken cancellationToken)
        {
            try
            {
                context.Users.Add(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success(resource);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public override async Task<OperationResult> DeleteAsync(User resource, CancellationToken cancellationToken)
        {
            try
            {
                context.Users.Remove(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success();
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public override async Task<User> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Users.FindAsync(id, cancellationToken);
        }

        public override async Task<User> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public override async Task<User> FindInAccessGroupAsync(User user, AccessGroup accessGroup, CancellationToken cancellationToken, bool deepSearch = false)
        {
            return await context
                .Users
                .Where(u => u.Id == user.Id)
                .Include(u => u.AccessGroups)
                .Where(uag => uag.AccessGroups.Any(ag => ag.Id == accessGroup.Id))
                .FirstOrDefaultAsync();
        }

        public override IQueryable<User> GetCollection(CancellationToken cancellationToken)
        {
            return context.Users.AsQueryable<User>();
        }

        public override async Task<OperationResult> UpdateAsync(User resource, CancellationToken cancellationToken)
        {
            try
            {
                context.Users.Update(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success(resource);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
    }

    public abstract class UserStore<TUser, TContext> :
        StoreBase<TContext>,
        IUserStore<TUser> 
        where TUser : User
        where TContext : DbContext
    {
        public UserStore(TContext ctx) : base(ctx) { }
        public abstract bool HasRecords { get; }
        public abstract Task<OperationResult> CreateAsync(TUser resource, CancellationToken cancellationToken);
        public abstract Task<OperationResult> DeleteAsync(TUser resource, CancellationToken cancellationToken);
        public abstract Task<TUser> FindByIdAsync(Guid id, CancellationToken cancellationToken);
        public abstract Task<TUser> FindByNameAsync(string name, CancellationToken cancellationToken);
        public abstract Task<TUser> FindInAccessGroupAsync(TUser user, AccessGroup accessGroup, CancellationToken cancellationToken, bool deepSearch = false);
        public abstract IQueryable<TUser> GetCollection(CancellationToken cancellationToken);
        public abstract Task<OperationResult> UpdateAsync(TUser resource, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Defines the default contract for the User IdentityStore base store.
    /// </summary>
    public interface IUserStore : IUserStore<User> { }

    /// <summary>
    /// Defines a contract for the User IdentityStore base store.
    /// </summary>
    /// <typeparam name="TUser">A concrete implementation of a class inheriting from <see cref="User"/>.</typeparam>
    /// <remarks>Inherit from this interface to add custom methods to the store.</remarks>
    public interface IUserStore<TUser> : IResourceStore<TUser> where TUser : User 
    {
        /// <summary>
        /// Search the presence of a User in an AccessGroup.
        /// </summary>
        /// <param name="user">The user to search for.</param>
        /// <param name="accessGroup">The AccessGroup where the User is supposed to be found.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="searchInParent">If <em>true</em>, performs a deep search (the correct implementation depends on the tree type).</param>
        /// <returns></returns>
        Task<TUser> FindInAccessGroupAsync(TUser user, AccessGroup accessGroup, CancellationToken cancellationToken, bool deepSearch = false);
    }
}
