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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            //Mapping
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            //Properties
            builder.Property(x => x.ProductName).HasMaxLength(255).IsRequired();

            builder.Property(x => x.ImagePath).HasMaxLength(255);
            builder.Property(x => x.UnitPrice).HasColumnType("money").IsRequired();
            builder.Property(x=>x.UnitsInStock).IsRequired();

            builder.HasData(SeedProductData());

        }

        private List<Product> SeedProductData()
        {
            List<Product> products = new List<Product>
            {

                new Product{Id=1,ProductName="Nike Airmax",UnitPrice=4000,UnitsInStock=500,ImagePath="https://productimages.hepsiburada.net/s/113/550/110000060380106.jpg",CategoryId=1},
                new Product{Id=2,ProductName="Lenovo",UnitPrice=30000,UnitsInStock=50,ImagePath="https://productimages.hepsiburada.net/s/498/550/110000549694124.jpg",CategoryId=2},
                new Product{Id=3,ProductName="MAC Ruj",UnitPrice=2000,UnitsInStock=10,ImagePath="https://productimages.hepsiburada.net/s/416/550/110000445267488.jpg",CategoryId=3}
               
            };
            return products;
        }
    }
}
