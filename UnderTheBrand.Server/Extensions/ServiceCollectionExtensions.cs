using Microsoft.Extensions.DependencyInjection;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Infrastructure.DAL.Providers;
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

        private static void AddTransient(IServiceCollection services)
        {
        }

        private static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<ITestProvider, TestProvider>();
            services.AddScoped<IBaseService, BaseService>();
        }

        private static void AddSingleton(IServiceCollection services)
        {
        }
    }
}
