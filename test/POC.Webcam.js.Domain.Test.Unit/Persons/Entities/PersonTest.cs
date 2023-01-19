using NUnit.Framework;
using POC.Webcam.js.Test.Tools.Base.Unit;
using POC.Webcam.js.Test.Tools.Constants;
using POC.Webcam.js.Test.Tools.Extensions;
using POC.Webcam.js.Test.Tools.Helpers;
using POC.Webcam.js.Test.Tools.Mocks;

namespace POC.Webcam.js.Domain.Test.Unit.Persons.Entities
{
    internal class PersonTest : UnitTest
    {
        [Test]
        [TestCase(-1)]
        public void Id_Invalid(long id)
        {
            //Arrange
            var person = MockData.Person;
            person.Id = id;

            //Act
            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(validationResult, Is.Not.Null);
                Assert.That(validationResult, Is.Not.Empty);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(StringsWithPredefinedSizes.StringWith51Caracters)]
        public void Name_Invalid(string name)
        {
            //Arrange
            var person = MockData.Person;
            person.Name = name;

            //Act
            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(validationResult, Is.Not.Null);
                Assert.That(validationResult, Is.Not.Empty);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(StringsWithPredefinedSizes.StringWith51Caracters)]
        public void Email_Invalid(string email)
        {
            //Arrange
            var person = MockData.Person;
            person.Email = email;

            //Act
            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(validationResult, Is.Not.Null);
                Assert.That(validationResult, Is.Not.Empty);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(StringsWithPredefinedSizes.StringWith101Caracters)]
        public void Password_Invalid(string password)
        {
            //Arrange
            var person = MockData.Person;
            person.Password = password;

            //Act
            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(validationResult, Is.Not.Null);
                Assert.That(validationResult, Is.Not.Empty);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Image_Invalid(string image)
        {
            //Arrange
            var person = MockData.Person;
            person.Image = image;

            //Act
            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(validationResult, Is.Not.Null);
                Assert.That(validationResult, Is.Not.Empty);
            });
        }
    }
}