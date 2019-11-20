using Entities;
using System.Data.Entity.ModelConfiguration;

namespace EF6Context
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(key => key.Id);

            Property(p => p.Name).HasMaxLength(30).IsRequired();

            HasMany(m => m.WebUsers).WithMany(m => m.Customers);
        }
    }
}