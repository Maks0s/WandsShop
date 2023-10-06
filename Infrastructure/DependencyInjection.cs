using Application.Common.Interfaces.Persistence;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WandsDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("WandDbConnection"))
                );

            services.AddScoped<IWandRepository, WandsRepository>();

            return services;
        }
    }
}
