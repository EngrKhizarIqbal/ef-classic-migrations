using System.Data.Entity.ModelConfiguration;
using Entities;

namespace EFMigrations
{
    internal class WebUserConfiguration : EntityTypeConfiguration<WebUser>
    {
        public WebUserConfiguration()
        {
            HasKey(key => key.Id);

            HasMany(m => m.Customers).WithMany(m => m.WebUsers);
        }
    }
}