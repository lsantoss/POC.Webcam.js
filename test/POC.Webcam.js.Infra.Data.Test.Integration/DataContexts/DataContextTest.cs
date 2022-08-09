using NUnit.Framework;
using POC.Webcam.js.Infra.Data.DataContexts;
using POC.Webcam.js.Infra.Settings;
using POC.Webcam.js.Test.Tools.Base.Integration;
using POC.Webcam.js.Test.Tools.Extensions;
using System.Data;

namespace POC.Webcam.js.Infra.Data.Test.Integration.DataContexts
{
    internal class DataContextTest : IntegrationTest
    {
        [Test]
        public void Contructor_Success()
        {
            var configuration = GetConfiguration();
            var connectionString = configuration["ConnectionString"];
            var appSettings = new AppSettings() { ConnectionString = connectionString };
            var dataContext = new DataContext(appSettings);

            TestContext.WriteLine(dataContext.ToJson());

            Assert.That(dataContext.Connection.State, Is.EqualTo(ConnectionState.Open));
        }

        [Test]
        public void Dispose_Success()
        {
            var configuration = GetConfiguration();
            var connectionString = configuration["ConnectionString"];
            var appSettings = new AppSettings() { ConnectionString = connectionString };
            var dataContext = new DataContext(appSettings);

            dataContext.Dispose();

            TestContext.WriteLine($"Connection: {dataContext.Connection.State}");

            Assert.That(dataContext.Connection.State, Is.EqualTo(ConnectionState.Closed));
        }
    }
}