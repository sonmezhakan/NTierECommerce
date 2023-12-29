using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierECommerce.DAL.Context;

namespace NTierECommerce.IOC.DependencyResolvers
{
    public static class ContextService
    {
        public static IServiceCollection AddECommerceDb(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            var configuration = provider.GetService<IConfiguration>();

            services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
