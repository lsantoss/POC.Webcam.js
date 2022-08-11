using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Webcam.js.Domain.Persons.Interfaces.Repositories;
using POC.Webcam.js.Infra.Data.DataContexts;
using POC.Webcam.js.Infra.Data.DataContexts.Interfaces;
using POC.Webcam.js.Infra.Data.Repositories;
using POC.Webcam.js.Infra.Settings;

namespace POC.Webcam.js.Infra.Crosscutting
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAppSettings(configuration);
            services.AddDataContexts();
            services.AddRepositories();
            services.AddElmahCore(configuration);
            return services;
        }

        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            return services;
        }

        public static IServiceCollection AddDataContexts(this IServiceCollection services)
        {
            services.AddScoped<IDataContext, DataContext>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddElmahCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmah<SqlErrorLog>(options => { options.ConnectionString = configuration["ConnectionString"]; });
            return services;
        }
    }
}