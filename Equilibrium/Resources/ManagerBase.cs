using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Resources
{
    /// <summary>
    /// Defines a Manager's abstract base class.
    /// </summary>
    /// <typeparam name="TStore">A concrete implementation of a <see cref="StoreBase{TContext}"/></typeparam>
    /// <typeparam name="TContext">The concrete implementation of <see cref="DbContext"/> where all operations of this Manager will be eventually performed.</typeparam>
    /// <remarks>Implementing a derived class of <see cref="IResourceStore{TResource, TKey}"/> or <see cref="IReadOnlyResourceStore{TResource, TKey}"/> will automatically make their methods available in the Manager.</remarks>
    public abstract class ManagerBase<TStore, TContext> : IDisposable
        where TStore : StoreBase<TContext>
        where TContext : DbContext
    {
        protected readonly TStore store;
        protected readonly CancellationToken cancellationToken;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="store">A concrete implementation of the Identity Store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        protected ManagerBase(TStore store, CancellationToken cancellationToken = default)
        {
            this.store = store;
            this.cancellationToken = cancellationToken;
        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            store?.Dispose();
        }
    }
}
