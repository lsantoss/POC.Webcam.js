using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Webcam.js.Domain.Person.Interfaces.Repositories;
using POC.Webcam.js.Infra.Data.Repositories;
using POC.Webcam.js.Infra.Settings;

namespace POC.Webcam.js.Infra.Crosscuting
{
    public static class IoC
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PessoaRepository>();
            return services;
        }

        public static IServiceCollection AddElmahCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = configuration["ConnectionString"];
            });

            return services;
        }
    }
}