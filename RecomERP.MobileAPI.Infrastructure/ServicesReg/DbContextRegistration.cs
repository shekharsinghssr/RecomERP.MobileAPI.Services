using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecomERP.MobileAPI.Infrastructure.Persistence;

namespace RecomERP.MobileAPI.Infrastructure.ServicesReg
{
    public static class DbContextRegistration
    {
        public static IServiceCollection AddDatabaseContexts(this IServiceCollection services, IConfiguration config)
        {
            // DbContexts
            services.AddDbContext<RecomERPContext>(opts => opts.UseSqlServer(config.GetConnectionString("RecomERPDb")));
            //services.AddDbContext<ERPCoreMasterDbContext>(opts => opts.UseSqlServer(config.GetConnectionString("ERPCoreMasterDb")));
            return services;
        }
    }
}
