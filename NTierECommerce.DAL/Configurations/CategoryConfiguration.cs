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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x=>x.CategoryName).IsRequired();

            //Seed Data
            builder.HasData(SeedCategoryData());
        }


        private List<Category> SeedCategoryData()
        {
            List<Category> categories = new List<Category>()
            {
                new Category{Id=1,CategoryName="Giyim",Description="Yazlık, kışlık, renkli, renksiz giyim ürünleri"},
                new Category{Id=2,CategoryName="Teknoloji",Description="Tablet, Telefon, bilgisayar"},
                 new Category{Id=3,CategoryName="Kozmetik",Description="parfüm, ruj, falan filan"}
            };

            return categories;
        }
    }
}
