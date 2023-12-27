using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierECommerce.DAL.Configurations;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.DAL.Context
{
    public class ECommerceContext:IdentityDbContext<AppUser,AppUserRole,int>
    {
        public ECommerceContext()
        {
            
        }
        public ECommerceContext(DbContextOptions<ECommerceContext> options):base(options)
        {
            
        }




        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            //AppUser
            builder.ApplyConfiguration(new AppUserConfiguration());

            //AppUserRole
            builder.ApplyConfiguration(new AppUserRoleConfiguration());


            //Category
            builder.ApplyConfiguration(new CategoryConfiguration());

            //Product
            builder.ApplyConfiguration(new ProductConfiguration());



            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("server=DESKTOP-J4PTH70;database=ECommerceDB;uid=sa;pwd=123;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
