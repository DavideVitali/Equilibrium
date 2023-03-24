using Equilibrium.Components.Communication;
using Equilibrium.Identity.Entities;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;

namespace Equilibrium.Identity.Store
{
    /// <summary>
    /// Default implementation of the ServerAction Store.
    /// </summary>
    public class ServerActionEntityStore : ServerActionEntityStore<ServerActionEntity, IdentityContext>
    {
        public ServerActionEntityStore(IdentityContext ctx) : base(ctx) { }

        public override bool HasRecords => context.Users.Any();

        public override async Task<OperationResult> CreateAsync(ServerActionEntity resource, CancellationToken cancellationToken)
        {
            try
            {
                context.ServerActions.Add(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success(resource);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public override async Task<OperationResult> DeleteAsync(ServerActionEntity resource, CancellationToken cancellationToken)
        {
            try
            {
                context.ServerActions.Remove(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success();
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public override async Task<ServerActionEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.ServerActions.FindAsync(id, cancellationToken);
        }

        public override async Task<ServerActionEntity> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await context.ServerActions.FirstOrDefaultAsync(u => u.Name == name);
        }

        public override IQueryable<ServerActionEntity> GetCollection(CancellationToken cancellationToken)
        {
            return context.ServerActions.AsQueryable<ServerActionEntity>();
        }

        public override async Task<OperationResult> UpdateAsync(ServerActionEntity resource, CancellationToken cancellationToken)
        {
            try
            {
                context.ServerActions.Update(resource);
                await context.SaveChangesAsync();
                return OperationResult.Success(resource);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
    }

    public abstract class ServerActionEntityStore<TServerActionEntity, TContext> :
        StoreBase<TContext>,
        IServerActionEntityStore<TServerActionEntity>
        where TServerActionEntity : ServerActionEntity
        where TContext : DbContext
    {
        public ServerActionEntityStore(TContext ctx) : base(ctx) { }

        public abstract bool HasRecords { get; }

        public abstract Task<OperationResult> CreateAsync(TServerActionEntity resource, CancellationToken cancellationToken);

        public abstract Task<OperationResult> DeleteAsync(TServerActionEntity resource, CancellationToken cancellationToken);

        public abstract Task<TServerActionEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken);

        public abstract Task<TServerActionEntity> FindByNameAsync(string name, CancellationToken cancellationToken);

        public abstract IQueryable<TServerActionEntity> GetCollection(CancellationToken cancellationToken);

        public abstract Task<OperationResult> UpdateAsync(TServerActionEntity resource, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Defines the default contract for the ServerAction base store.
    /// </summary>
    public interface IServerActionEntityStore : IServerActionEntityStore<ServerActionEntity> { }

    /// <summary>
    /// Defines a contract for the ServerActionEntity base store.
    /// </summary>
    /// <typeparam name="TServerActionEntity">A concrete implementation of a class inheriting from <see cref="ServerActionEntity"/>.</typeparam>
    /// <remarks>Inherit from this interface to add custom methods to the store.</remarks>
    public interface IServerActionEntityStore<TServerActionEntity> : IResourceStore<TServerActionEntity> where TServerActionEntity : ServerActionEntity
    {
    }
}
