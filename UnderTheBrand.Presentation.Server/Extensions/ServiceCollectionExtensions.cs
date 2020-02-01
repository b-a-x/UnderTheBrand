using Microsoft.Extensions.DependencyInjection;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Infrastructure.Dal.Context;
using UnderTheBrand.Infrastructure.Dal.InitializeDB;
using UnderTheBrand.Infrastructure.Dal.Repositories;
using UnderTheBrand.Presentation.Server.Data;

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

        private static void AddTransient(IServiceCollection service)
        {
        }

        private static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IManagerInitialize, ManagerInitialize>();
        }

        private static void AddSingleton(IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastService>();
        }
    }
}
