using Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF6WithCore.EF6
{
    public class EF6WithCoreEF6Context : DbContext
    {
        public EF6WithCoreEF6Context(string connString) : base(connString)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new NullDatabaseInitializer<EF6WithCoreEF6Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new WebUserConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
    }

    public class EF6WithCoreEF6ContextFactory : IDbContextFactory<EF6WithCoreEF6Context>
    {
        public EF6WithCoreEF6Context Create()
        {
            return new EF6WithCoreEF6Context("Server=(localdb)\\mssqllocaldb; Database=EF6MVCCore; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }
}
