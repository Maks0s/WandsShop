using Application.Common.Behaviors;
using Application.Wands.Commands.Create;
using Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            return services;
        }
    }
}
