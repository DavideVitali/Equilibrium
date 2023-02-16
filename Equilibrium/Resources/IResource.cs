using System.ComponentModel.DataAnnotations;

namespace Equilibrium.Resources
{
    /// <summary>
    /// Defines the default implementation for <see cref="IResource{TKey}"/>
    /// </summary>
    /// <remarks>The type of the <see cref="IResource{TKey}.Id"/> property is <see cref="Guid"/> by default.</remarks>
    public interface IResource : IResource<Guid>
    {

    }

    /// <summary>
    /// Define a contract for any DB entity <see cref="CianHub"/>
    /// </summary>
    /// <typeparam name="TKey">The type of the Id property</typeparam>
    public interface IResource<TKey>
    {
        /// <summary>
        /// Resource Id
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Resource name
        /// </summary>
        string Name { get; }

        /// <inheritdoc/>
        int GetHashCode();
    }
}