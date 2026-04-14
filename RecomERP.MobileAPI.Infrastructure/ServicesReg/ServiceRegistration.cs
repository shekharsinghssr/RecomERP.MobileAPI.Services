using Microsoft.Extensions.DependencyInjection;
using RecomERP.API.Infrastructure.Services;
using RecomERP.MobileAPI.Application.IServices;
using RecomERP.MobileAPI.Application.IServices.DataServices;
using RecomERP.MobileAPI.Application.Mapping;
using RecomERP.MobileAPI.Application.Services;
using RecomERP.MobileAPI.Domain.IRepositories;
using RecomERP.MobileAPI.Infrastructure.Persistence;
using RecomERP.MobileAPI.Infrastructure.Repositories;
using RecomERP.MobileAPI.Infrastructure.Services;

namespace RecomERP.MobileAPI.Infrastructure.ServicesReg
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Add Infrastructure
            services.AddScoped<ISqlDataService, SqlDataService>();
            services.AddScoped<IDataServiceContext, DataServiceContext>();


            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddLogging();

            // Add HomeBanner
            services.AddScoped<IHomeBannerRepository, HomeBannerRepository>();
            services.AddScoped<IHomeBannerService, HomeBannerService>();

            // Add ThumbBanner
            services.AddScoped<IThumbBannerRepository, ThumbBannerRepository>();
            services.AddScoped<IThumbBannerService, ThumbBannerService>();

            // Add HomeProductBlock
            services.AddScoped<IHomeProductBlockRepository, HomeProductBlockRepository>();
            services.AddScoped<IHomeProductBlockService, HomeProductBlockService>();

            // Add HomeProductBlockItem
            services.AddScoped<IHomeProductBlockItemRepository, HomeProductBlockItemRepository>();
            services.AddScoped<IHomeProductBlockItemService, HomeProductBlockItemService>();


        }
    }
}
