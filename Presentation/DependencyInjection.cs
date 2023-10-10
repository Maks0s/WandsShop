using Microsoft.Extensions.Options;
using Presentation.Common.Mapping;
using Presentation.Common.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScoped<IMapper, Mapper>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
