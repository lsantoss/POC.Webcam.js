using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using DependencyInjectionExtensionApi = POC.Webcam.js.Infra.Crosscutting.DependencyInjectionExtension;

namespace POC.Webcam.js.Test.Tools
{
    [TestFixture]
    public class Startup
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;

        public Startup()
        {
            _services = new ServiceCollection();

            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, false).AddEnvironmentVariables().Build();

            _services = DependencyInjectionExtensionApi.AddDependencies(_services, _configuration);

            _serviceProvider = _services.BuildServiceProvider();
        }

        protected IConfiguration GetConfigurationApi() => _configuration;
        protected IServiceCollection GetServices() => _services;
        protected T GetServices<T>() => (T)_serviceProvider.GetService(typeof(T));
    }
}