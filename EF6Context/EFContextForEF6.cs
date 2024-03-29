﻿using Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF6Context
{
    public class EFContextForEF6 : DbContext
    {
        public EFContextForEF6() : base("DefaultConnection")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new NullDatabaseInitializer<EFContextForEF6>());
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
}
