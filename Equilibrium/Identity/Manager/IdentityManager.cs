using Equilibrium.Identity.Entities;
using Equilibrium.Identity.Store;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Identity.Manager
{
    
    /// <summary>
    /// Default Identity Manager. Serves as the entry-point for the underlying identity managers through which all database operations are performed.
    /// </summary>
    public class IdentityManager
    {
        /// <summary>
        /// The Users manager.
        /// </summary>
        public readonly UserManager Users;

        /// <summary>
        /// The AccessGroups manager.
        /// </summary>
        public readonly AccessGroupManager AccessGroups;

        /// <summary>
        /// The ServerActionEntities manager.
        /// </summary>
        public readonly ServerActionManager ServerActions;

        public IdentityManager(
            UserManager userManager,
            AccessGroupManager accessGroupManager,
            ServerActionManager serverActionManager
            )
        {
            AccessGroups = accessGroupManager ?? throw new ArgumentNullException(nameof(accessGroupManager));
            ServerActions = serverActionManager ?? throw new ArgumentNullException(nameof(serverActionManager));
            Users = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
    }

    /// <summary>
    /// Identity manager to encapsulate the custom implementations of the User, AccessGroup and ServerAction managers.
    /// </summary>
    /// <typeparam name="TUserManager"></typeparam>
    /// <typeparam name="TUserEntity"></typeparam>
    /// <typeparam name="TUserStore"></typeparam>
    /// <typeparam name="TAccessGroupManager"></typeparam>
    /// <typeparam name="TAccessGroupEntity"></typeparam>
    /// <typeparam name="TAccessGroupStore"></typeparam>
    /// <typeparam name="TServerActionManager"></typeparam>
    /// <typeparam name="TServerActionEntity"></typeparam>
    /// <typeparam name="TServerActionStore"></typeparam>
    public class IdentityManager<
        // user generics
        TUserManager, 
        TUserEntity, 
        TUserStore,
        // accessGroup generics
        TAccessGroupManager,
        TAccessGroupEntity,
        TAccessGroupStore,
        // serverAction generics
        TServerActionManager,
        TServerActionEntity,
        TServerActionStore>
        where TUserManager : UserManager<TUserEntity, TUserStore, DbContext>
        where TUserEntity : User
        where TUserStore : UserStore<TUserEntity, DbContext>
        where TAccessGroupManager: AccessGroupManager<TAccessGroupEntity, TAccessGroupStore, DbContext>
        where TAccessGroupEntity : AccessGroup
        where TAccessGroupStore : AccessGroupStore<TAccessGroupEntity, DbContext>
        where TServerActionManager: ServerActionManager<TServerActionEntity, TServerActionStore, DbContext>
        where TServerActionEntity : ServerActionEntity
        where TServerActionStore : ServerActionEntityStore<TServerActionEntity, DbContext>
    {
        /// <summary>
        /// The Users manager.
        /// </summary>
        public readonly TUserManager Users;

        /// <summary>
        /// The AccessGroups manager.
        /// </summary>
        public readonly TAccessGroupManager AccessGroups;

        /// <summary>
        /// The ServerActionEntitier manager.
        /// </summary>
        public readonly TServerActionManager ServerActions;

        public IdentityManager(
            TUserManager userManager, 
            TAccessGroupManager accessGroupManager, 
            TServerActionManager serverActionManager)
        {
            AccessGroups = accessGroupManager ?? throw new ArgumentNullException(nameof(accessGroupManager));
            ServerActions = serverActionManager ?? throw new ArgumentNullException(nameof(serverActionManager));
            Users = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
    } 
}
