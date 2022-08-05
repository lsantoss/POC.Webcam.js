using NUnit.Framework;
using POC.Webcam.js.Test.Tools.Mocks;

namespace POC.Webcam.js.Test.Tools.Base.Common
{
    [TestFixture]
    public class BaseTest : Startup
    {
        protected MockData MockData { get; set; }

        public BaseTest() : base() => MockData = new MockData();

        [OneTimeSetUp]
        protected virtual void OneTimeSetUp() => MockData = new MockData();

        [OneTimeTearDown]
        protected virtual void OneTimeTearDown() => MockData = null;

        [SetUp]
        protected virtual void SetUp() => MockData = new MockData();

        [TearDown]
        protected virtual void TearDown() => MockData = null;
    }
}