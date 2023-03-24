namespace Equilibrium.Resources
{
    /// <summary>
    /// Defines a contract for a store holding db entities that are supposed to be read-only.
    /// </summary>
    /// <typeparam name="TResource">Type of resource or db entity.</typeparam>
    /// <typeparam name="TKey">Type of the key associated to the ID property of the resource.</typeparam>
    public interface IReadOnlyResourceStore<TResource, TKey> : IDisposable
    {
        /// <summary>
        /// Find the resource by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResource> FindByIdAsync(TKey id, CancellationToken cancellationToken);

        /// <summary>
        /// Find the resource by its Name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResource> FindByNameAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Get the resources for further queries.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IQueryable<TResource> GetCollection(CancellationToken cancellationToken);
    }
}
