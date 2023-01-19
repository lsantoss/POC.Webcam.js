using NUnit.Framework;
using POC.Webcam.js.Domain.Persons.Interfaces.Repositories;
using POC.Webcam.js.Test.Tools.Base.Integration;
using POC.Webcam.js.Test.Tools.Constants;
using POC.Webcam.js.Test.Tools.Extensions;
using POC.Webcam.js.Test.Tools.Mocks;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace POC.Webcam.js.Infra.Data.Test.Integration.Persons.Repositories
{
    internal class PersonRepositoryTest : IntegrationTest
    {
        private readonly IPersonRepository _repository;

        public PersonRepositoryTest() => _repository = GetServices<IPersonRepository>();

        [Test]
        public async Task Insert_SuccessAsync()
        {
            //Arrange
            var person = MockData.Person;

            //Act
            person.Id = await _repository.InsertAsync(person);

            var result = await _repository.GetAsync(person.Id);

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(person.Id));
                Assert.That(result.Name, Is.EqualTo(person.Name));
                Assert.That(result.Birth, Is.EqualTo(person.Birth));
                Assert.That(result.Email, Is.EqualTo(person.Email));
                Assert.That(result.Password, Is.EqualTo(person.Password));
                Assert.That(result.Image, Is.EqualTo(person.Image));
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase(StringsWithPredefinedSizes.StringWith51Caracters)]
        public void Insert_Invalid_Name_Exception(string name)
        {
            //Arrange
            var person = MockData.Person;
            person.Name = name;

            //Assert
            Assert.ThrowsAsync<SqlException>(() => _repository.InsertAsync(person));
        }

        [Test]
        public void Insert_Invalid_Birth_Exception()
        {
            //Arrange
            var person = MockData.Person;
            person.Birth = DateTime.MinValue;

            //Assert
            Assert.ThrowsAsync<SqlTypeException>(() => _repository.InsertAsync(person));
        }

        [Test]
        [TestCase(null)]
        [TestCase(StringsWithPredefinedSizes.StringWith51Caracters)]
        public void Insert_Invalid_Email_Exception(string email)
        {
            //Arrange
            var person = MockData.Person;
            person.Email = email;

            //Assert
            Assert.ThrowsAsync<SqlException>(() => _repository.InsertAsync(person));
        }

        [Test]
        [TestCase(null)]
        [TestCase(StringsWithPredefinedSizes.StringWith101Caracters)]
        public void Insert_Invalid_Password_Exception(string password)
        {
            //Arrange
            var person = MockData.Person;
            person.Password = password;

            //Assert
            Assert.ThrowsAsync<SqlException>(() => _repository.InsertAsync(person));
        }

        [Test]
        [TestCase(null)]
        public void Insert_Invalid_Image_Exception(string image)
        {
            //Arrange
            var person = MockData.Person;
            person.Image = image;

            //Assert
            Assert.ThrowsAsync<SqlException>(() => _repository.InsertAsync(person));
        }

        [Test]
        public async Task Delete_Success()
        {
            //Arrange
            var person = MockData.Person;

            await _repository.InsertAsync(person);

            //Act
            await _repository.DeleteAsync(person.Id);

            var result = await _repository.GetAsync(person.Id);

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Get_Registred_Id_Success()
        {
            //Arrange
            var person = MockData.Person;

            await _repository.InsertAsync(person);

            //Act
            var result = await _repository.GetAsync(person.Id);

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(person.Id));
                Assert.That(result.Name, Is.EqualTo(person.Name));
                Assert.That(result.Birth, Is.EqualTo(person.Birth));
                Assert.That(result.Email, Is.EqualTo(person.Email));
                Assert.That(result.Password, Is.EqualTo(person.Password));
                Assert.That(result.Image, Is.EqualTo(person.Image));
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(long.MaxValue)]
        public async Task Get_Not_Registred_Id_Success(long id)
        {
            //Act
            var result = await _repository.GetAsync(id);

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task List_Registred_Ids_Success()
        {
            //Arrange
            var person = MockData.Person;

            await _repository.InsertAsync(person);

            //Act
            var result = await _repository.ListAsync();

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Has.Count.EqualTo(1));
                Assert.That(result[0].Id, Is.EqualTo(person.Id));
                Assert.That(result[0].Name, Is.EqualTo(person.Name));
                Assert.That(result[0].Birth, Is.EqualTo(person.Birth));
                Assert.That(result[0].Email, Is.EqualTo(person.Email));
                Assert.That(result[0].Password, Is.EqualTo(person.Password));
                Assert.That(result[0].Image, Is.EqualTo(person.Image));
            });
        }

        [Test]
        public async Task List_Not_Registred_Ids_Success()
        {
            //Act
            var result = await _repository.ListAsync();

            TestContext.WriteLine(result.ToJson());

            //Assert
            Assert.That(result, Is.Empty);
        }
    }
}