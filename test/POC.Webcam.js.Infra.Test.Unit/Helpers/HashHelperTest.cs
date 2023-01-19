using NUnit.Framework;
using POC.Webcam.js.Infra.Helpers;
using POC.Webcam.js.Test.Tools.Base.Unit;
using POC.Webcam.js.Test.Tools.Extensions;

namespace POC.Webcam.js.Infra.Test.Unit.Helpers
{
    internal class HashHelperTest : UnitTest
    {
        [Test]
        public void GenerateHash_Null_Parameter()
        {
            //Act
            var result = HashHelper.GenerateHash(null);

            TestContext.WriteLine(result);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("123123")]
        public void GenerateHash_Not_Null_Parameters(string text)
        {
            //Act
            var result = HashHelper.GenerateHash(text);

            TestContext.WriteLine(result);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.Not.Empty); ;
                Assert.That(result, Is.Not.EqualTo(text));
            });
        }

        [Test]
        public void ValidateHash_Invalid_Text_Null()
        {
            //Act
            var result = HashHelper.ValidateHash(null, "$2a$11$QLUJ3JUb123NZwysK0ooTuUrkC7nf.Uk6IiOrSuuD15YY2lLItiFu");

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("123123")]
        public void ValidateHash_Valid(string text)
        {
            //Arrange
            var hash = HashHelper.GenerateHash(text);

            //Act
            var result = HashHelper.ValidateHash(text, hash);

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.That(result, Is.True);
        }
    }
}