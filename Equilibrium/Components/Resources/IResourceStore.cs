using Equilibrium.Components.Communication;

namespace Equilibrium.Components.Resources
{
    /// <summary>
    /// Defines a contract for a store holding db entities.
    /// </summary>
    /// <typeparam name="TResource">Type of the resource having Id property of type <see cref="Guid"/></typeparam>
    public interface IResourceStore<TResource> : IResourceStore<TResource, Guid>
    {

    }

    /// <summary>
    /// Defines a contract for a store holding db entities.
    /// </summary>
    /// <typeparam name="TResource">The type of the db entity.</typeparam>
    /// <typeparam name="TKey">Type of the key associated to the ID property of the resource.</typeparam>
    /// <remarks>Extends <see cref="IReadOnlyResourceStore{TResource, TKey}"/>, including writing methods.</remarks>
    public interface IResourceStore<TResource, TKey> : IReadOnlyResourceStore<TResource, TKey>
    {
        /// <summary>
        /// Create a new resource in the store.
        /// </summary>
        /// <param name="resource">Resource to be added</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationResult> CreateAsync(TResource resource, CancellationToken cancellationToken);

        /// <summary>
        /// Update an existing resource in the store.
        /// </summary>
        /// <param name="resource">Resource to be update.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationResult> UpdateAsync(TResource resource, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a resource
        /// </summary>
        /// <param name="resource">Resource to be deleted.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationResult> DeleteAsync(TResource resource, CancellationToken cancellationToken);

        /// <summary>
        /// Query the underlying db to see whether it contains records or not.
        /// </summary>
        /// <returns></returns>
        bool HasRecords { get; }
    }
}
