using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Webcam.js.Domain.Person.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<long> Insert(Entities.Person person);
        Task Update(Entities.Person person);
        Task Delete(long id);

        Task<Entities.Person> Get(long id);
        Task<List<Entities.Person>> List();
    }
}