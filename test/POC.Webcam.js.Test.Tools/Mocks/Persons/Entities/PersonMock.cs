using POC.Webcam.js.Domain.Persons.Entities;
using POC.Webcam.js.Infra.Helpers;
using System;

namespace POC.Webcam.js.Test.Tools.Mocks.Persons.Entities
{
    public static class PersonMock
    {
        public static Person GetPerson() => new()
        {
            Id = 1,
            Name = "Lucas",
            Birth = new DateTime(2000, 10, 5),
            Email = "email@hotmail.com",
            Password = HashHelper.GenerateHash("123"),
            Image = "Image"
        };
    }
}