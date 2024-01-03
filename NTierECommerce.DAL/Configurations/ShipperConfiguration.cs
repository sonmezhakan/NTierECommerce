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
	public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
	{
		public void Configure(EntityTypeBuilder<Shipper> builder)
		{
			builder.Property(x=>x.CompanyName).HasMaxLength(255).IsRequired();

			builder.HasData(SeedProductData());
		}

		private List<Shipper> SeedProductData()
		{
			List<Shipper> shippers = new List<Shipper>
			{
				new Shipper
				{
					Id = 1,
					CompanyName = "Aras",
				},
				new Shipper
				{
					Id = 2,
					CompanyName = "Mng",
				},
				new Shipper
				{
					Id = 3,
					CompanyName = "Ups",
				}


			};
			return shippers;
		}
	}
}
