using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Auth.Authentication;
using Infrastructure.Auth.Common.Configurations;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Common.Constants;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddPersistence(configuration);
            services.AddAuth(configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<WandsDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ShopDbConnection")
                    )
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
                        }
                    )
                );

            return services;
        }


        private static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

            })
                .AddEntityFrameworkStores<AppUserDbContext>();

            JwtConfig jwtConfig = new JwtConfig();
            configuration.Bind(JwtConfig.SectionName, jwtConfig);
            services.AddSingleton(Options.Create(jwtConfig));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = jwtConfig.Issuer,
                        ValidateIssuer = true,

                        ValidAudience = jwtConfig.Audience,
                        ValidateAudience = true,

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtConfig.SecretKey)
                            ),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddSingleton<IJwtGenerator, JwtGenerator>();

            return services;
        }
    }
}
