using POC.Webcam.js.Domain.Persons.Entities;
using POC.Webcam.js.Test.Tools.Mocks.Persons.Entities;

namespace POC.Webcam.js.Test.Tools.Mocks
{
    public class MockData
    {
        public Person Person { get; }

        public MockData()
        {
            Person = PersonMock.GetPerson();
        }
    }
}