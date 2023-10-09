using Application.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => 
                {
                    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
                    cfg.AddOpenBehavior(typeof(ValidationBehavion<,>));
                }
            );

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            ValidatorOptions.Global.LanguageManager.Enabled = false;

            return services;
        }
    }
}
