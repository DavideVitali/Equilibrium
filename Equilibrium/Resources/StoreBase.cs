using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Resources
{
    /// <summary>
    /// Defines a Store's abstract base class.
    /// </summary>
    /// <typeparam name="TContext">A concrete implementation of <see cref="DbContext"/> where all operation of this Store will be performed.</typeparam>
    public abstract class StoreBase<TContext> : IDisposable where TContext : DbContext
    {
        bool disposed;
        protected readonly TContext context;

        public StoreBase(TContext ctx)
        {
            context = ctx;
        }

        /// <inheritdoc/>
        protected void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                context.Dispose();
                disposed = true;
            }
        }

        ///<inheritdoc/>
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
