using Entities;
using System.Data.Entity.ModelConfiguration;

namespace EFMigrations
{
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(key => key.Id);

            HasMany(m => m.WebUsers).WithMany(m => m.Customers);
        }
    }
}