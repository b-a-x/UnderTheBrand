using Microsoft.Extensions.DependencyInjection;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Infrastructure.Dal.Repositories;
using UnderTheBrand.Presentation.Server.Data;
using UnderTheBrand.Presentation.Server.Services;
using UnderTheBrand.Presentation.Server.Services.Interfaces;

namespace UnderTheBrand.Presentation.Server.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddInjection(this IServiceCollection services)
        {
            AddTransient(services);
            AddScoped(services);
            AddSingleton(services);
        }

        private static void AddTransient(IServiceCollection _)
        {
        }

        private static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBaseService, BaseService>();
        }

        private static void AddSingleton(IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastService>();
        }
    }
}
