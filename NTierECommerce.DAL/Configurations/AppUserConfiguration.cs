using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            
            builder.Property(x => x.UserName).HasMaxLength(64).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(255).IsRequired();
            builder.Property(x=>x.PhoneNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500);
        }
    }
}
