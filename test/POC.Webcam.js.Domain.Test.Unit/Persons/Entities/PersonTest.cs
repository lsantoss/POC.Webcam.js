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
            var person = MockData.Person;
            person.Id = id;

            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

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
            var person = MockData.Person;
            person.Name = name;

            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

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
            var person = MockData.Person;
            person.Email = email;

            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

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
            var person = MockData.Person;
            person.Password = password;

            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

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
            var person = MockData.Person;
            person.Image = image;

            var validationResult = ValidateModelHelper.ValidateModelWithAnotations(person);

            TestContext.WriteLine(validationResult.ToJson());

            Assert.Multiple(() =>
            {
                Assert.That(validationResult, Is.Not.Null);
                Assert.That(validationResult, Is.Not.Empty);
            });
        }
    }
}