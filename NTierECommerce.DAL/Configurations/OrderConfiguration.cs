using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierECommerce.Entities.Entities;

namespace NTierECommerce.DAL.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.Ignore(x => x.Id);
			builder.HasKey(x =>new { x.OrderId});

			builder.Property(x => x.Freight).HasColumnType("money");

			
			builder.HasOne(x => x.Shipper).WithMany(x => x.Orders).HasForeignKey(x => x.ShipperId);

		}
	}
}
