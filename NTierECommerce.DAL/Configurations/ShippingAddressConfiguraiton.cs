using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.DAL.Configurations
{
	public class ShippingAddressConfiguraiton : IEntityTypeConfiguration<ShippingAddress>
	{
		public void Configure(EntityTypeBuilder<ShippingAddress> builder)
		{
			builder.HasOne(x => x.AppUser).WithMany(x => x.ShippingAddresses).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Restrict);
			
		}
	}
}
