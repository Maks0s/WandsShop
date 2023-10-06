using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Common.Constants;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            services.AddPersistence(builder.Configuration);
            services.AddAuth(builder, builder.Configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<WandsDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ShopDbConnection"))
                );

            services.AddScoped<IWandRepository, WandsRepository>();

            services.AddDbContext<AppUserDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ShopDbConnection"),
                    options =>
                    {
                        options.MigrationsHistoryTable(
                            HistoryRepository.DefaultTableName,
                            DbSchemas.UsersSchema
                            );
                    })
                );

            return services;
        }
    }
}
