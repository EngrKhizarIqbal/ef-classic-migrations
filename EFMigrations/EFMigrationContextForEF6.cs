using Entities;
using EntitiesConfigurations;
using System.Data.Entity;

namespace EFMigrations
{
    internal class EFMigrationContextForEF6 : DbContext
    {
        public EFMigrationContextForEF6() : base("DefaultConnection")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new NullDatabaseInitializer<EFMigrationContextForEF6>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new WebUserConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<WebUser> WebUsers { get; set; }
    }
}
