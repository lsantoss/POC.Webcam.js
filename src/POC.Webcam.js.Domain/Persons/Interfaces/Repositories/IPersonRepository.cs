using POC.Webcam.js.Domain.Persons.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Webcam.js.Domain.Persons.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<long> Insert(Person person);
        Task Update(Person person);
        Task Delete(long id);

        Task<Person> Get(long id);
        Task<List<Person>> List();
    }
}
