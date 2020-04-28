using Microsoft.Extensions.DependencyInjection;
using UnderTheBrand.Domain.Interface.Repositories;
using UnderTheBrand.Infrastructure.SqliteDal.InitializeDB;
using UnderTheBrand.Infrastructure.SqliteDal.Repositories;

namespace UnderTheBrand.Presentation.Web.Server.Extensions
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
        }
    }
}