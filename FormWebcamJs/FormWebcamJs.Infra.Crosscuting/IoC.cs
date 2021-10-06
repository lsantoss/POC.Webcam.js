using ElmahCore.Mvc;
using ElmahCore.Sql;
using FormWebcamJs.Domain.Interfaces.Repositories;
using FormWebcamJs.Infra.Data.Repositories;
using FormWebcamJs.Infra.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormWebcamJs.Infra.Crosscuting
{
    public static class IoC
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settingsDatabase = new SettingsDatabase();
            configuration.GetSection("SettingsDatabase").Bind(settingsDatabase);
            services.AddSingleton(settingsDatabase);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            return services;
        }

        public static IServiceCollection AddElmahCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = configuration["SettingsDatabase:ConnectionString"];
            });

            return services;
        }
    }
}