using AutoMapper;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Service;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CarModelManagement.Configuration
{
    public static class DependancyConfiguration
    {
        public static void AddDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICarModelRepository, CarModelRepository>();
            services.AddTransient<ICarModelService, CarModelService>();

            services.AddTransient<IAuthservice,AuthenticationService>();

            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IcompanyService, CompanyModelService>();

            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IImageService, ImageService>();

            services.AddTransient<IHeaderService, headerService>();
            services.AddTransient<IHeaderRepository, HeaderRepository>();

            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IItemRepository, ItemRepository>();

            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IInventoryrepository, Inventoryrepository>();

            services.AddTransient<IOverheadService, OverheadService>();
            services.AddTransient<IOverheadRepository, OverheadRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

        }
    }
}
