using Equilibrium.Identity.Entities;
using Equilibrium.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Identity
{
    public class IdentityContext : IdentityContext<User, AccessGroup, ServerActionEntity>
    {
        /// <inheritdoc/>
        public IdentityContext(DbContextOptions options) : base(options) { }

        /// <inheritdoc/>
        protected IdentityContext() : base() { }
    }

    public class IdentityContext<TUser> : IdentityContext<TUser, AccessGroup, ServerActionEntity> where TUser : User
    {
        /// <inheritdoc/>
        public IdentityContext(DbContextOptions options) : base(options) { }

        /// <inheritdoc/>
        protected IdentityContext() : base() { }
    }

    public class IdentityContext<TUser, TAccessGroup> : IdentityContext<TUser, TAccessGroup, ServerActionEntity> 
        where TUser : User
        where TAccessGroup : AccessGroup
    {
        /// <inheritdoc/>
        public IdentityContext(DbContextOptions options) : base(options) { }

        /// <inheritdoc/>
        protected IdentityContext() : base() { }
    }

    public abstract class IdentityContext<TUser, TAccessGroup, TServerActionEntity> : DbContext
        where TUser : User
        where TAccessGroup : AccessGroup
        where TServerActionEntity : ServerActionEntity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The <see cref="DbContext"/> options.</param>
        public IdentityContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        protected IdentityContext() : base() { }

        /// <summary>
        /// A <see cref="DbSet{TEntity}"/> collection of Users.
        /// </summary>
        public virtual DbSet<TUser> Users { get; set; } = default!;

        /// <summary>
        /// A <see cref="DbSet{TEntity}"/> collection of Access Groups.
        /// </summary>
        public virtual DbSet<AccessGroup> AccessGroups { get; set; } = default!;

        /// <summary>
        /// A <see cref="DbSet{TEntity}"/> collection of Server Actions.
        /// </summary>
        public virtual DbSet<ServerActionEntity> ServerActions { get; set; } = default!;

        /// <summary>
        /// Configuration of the Identity.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //TODO: Set relationships.
        }
    }
    

}
