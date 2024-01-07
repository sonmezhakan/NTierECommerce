using Microsoft.Extensions.DependencyInjection;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.BLL.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.IOC.DependencyResolvers
{
    public static class RepositoryService
    {
        public static  IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            //AddRepositories

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IShippingAddressRepository, ShippingAddressRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();

            return services;
        }
    }
}
