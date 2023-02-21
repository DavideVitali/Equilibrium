using Equilibrium.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Equilibrium.Identity
{
    public class IdentityContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<User> Users { get; set; }
        public DbSet<AccessGroup> AccessGroups { get; set; }
        public DbSet<ServerActionEntity> ServerActions { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "identity.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
