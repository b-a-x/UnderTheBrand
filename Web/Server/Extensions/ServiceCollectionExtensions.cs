﻿using Microsoft.Extensions.DependencyInjection;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Infrastructure.Dal.InitializeDB;
using UnderTheBrand.Infrastructure.Dal.Repositories;

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