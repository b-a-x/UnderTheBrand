using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using UnderTheBrand.Domain.Interface.Repositories;
using UnderTheBrand.Infrastructure.SqliteDal.InitializeDB;
using UnderTheBrand.Infrastructure.SqliteDal.Repositories;

namespace UnderTheBrand.Presentation.Web.Server.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        private static string _connectionString;

        internal static void AddInjection(this IServiceCollection services, string connectionString)
        {
            _connectionString = connectionString;

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
            services.AddSingleton<IDbConnection>(x =>
            {
                var connection = new SqliteConnection(_connectionString);
                connection.Open();
                return connection;
            });
        }

        private static void AddSingleton(IServiceCollection services)
        {
        }
    }
}