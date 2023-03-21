using Equilibrium.Identity.Store;
using Equilibrium.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Identity.Manager
{
    // TODO: Identity Manager has to unite 3 different managers: Users, AccessGroups, ServerActionEntities

    /// <summary>
    /// Default Identity Manager, encapsulating the underlying identity store where all database operations are performed.
    /// </summary>
    public class IdentityManager : 
        ManagerBase<UserStore, IdentityContext>,
        UserStore
    {
        /// <inheritdoc/>
        public IdentityManager(UserStore store, CancellationToken cancellationToken = default) : base(store, cancellationToken)
        {
        }
    }
}
