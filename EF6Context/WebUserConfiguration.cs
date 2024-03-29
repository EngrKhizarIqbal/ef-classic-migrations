﻿using Entities;
using System.Data.Entity.ModelConfiguration;

namespace EF6Context
{
    public class WebUserConfiguration : EntityTypeConfiguration<WebUser>
    {
        public WebUserConfiguration()
        {
            HasKey(key => key.Id);

            Property(p => p.Name).HasMaxLength(20).IsRequired();

            HasMany(m => m.Customers).WithMany(m => m.WebUsers);
        }
    }
}