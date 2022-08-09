using POC.Webcam.js.Domain.Persons.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Webcam.js.Domain.Persons.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<long> InsertAsync(Person person);
        Task DeleteAsync(long id);

        Task<Person> GetAsync(long id);
        Task<List<Person>> ListAsync();
    }
}
