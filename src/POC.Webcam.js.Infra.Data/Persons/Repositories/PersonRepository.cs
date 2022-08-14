using Dapper;
using POC.Webcam.js.Domain.Persons.Entities;
using POC.Webcam.js.Domain.Persons.Interfaces.Repositories;
using POC.Webcam.js.Infra.Data.DataContexts.Interfaces;
using POC.Webcam.js.Infra.Data.Persons.Queries;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Webcam.js.Infra.Data.Persons.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDataContext _dataContext;
        private readonly DynamicParameters _parameters = new();

        public PersonRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<long> InsertAsync(Person person)
        {
            _parameters.Add("Name", person.Name, DbType.String);
            _parameters.Add("Birth", person.Birth, DbType.DateTime);
            _parameters.Add("Email", person.Email, DbType.String);
            _parameters.Add("Password", person.Password, DbType.String);
            _parameters.Add("Image", person.Image, DbType.String);

            return await _dataContext.Connection.ExecuteScalarAsync<long>(PersonQueries.Insert, _parameters);
        }

        public async Task DeleteAsync(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            await _dataContext.Connection.ExecuteAsync(PersonQueries.Delete, _parameters);
        }

        public async Task<Person> GetAsync(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            return (await _dataContext.Connection.QueryAsync<Person>(PersonQueries.Get, _parameters)).FirstOrDefault();
        }

        public async Task<List<Person>> ListAsync()
        {
            return (await _dataContext.Connection.QueryAsync<Person>(PersonQueries.List)).ToList();
        }
    }
}