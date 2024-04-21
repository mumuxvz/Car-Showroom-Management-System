using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarModelManagement.infra.Domain;

namespace CarModelManagement.Configuration
{
    public static class SqlServerConfiguration
    {
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Carmanage");


            services.AddDbContext<CarModelContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly("CarModelManagement.infra.Domain");
                    sqlServerOptionsAction.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            }, ServiceLifetime.Scoped);

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CarModelContext>()
                .AddDefaultTokenProviders();
        }
    }
}
