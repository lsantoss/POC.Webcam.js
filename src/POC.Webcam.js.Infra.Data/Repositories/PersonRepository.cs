using Dapper;
using POC.Webcam.js.Domain.Persons.Entities;
using POC.Webcam.js.Domain.Persons.Interfaces.Repositories;
using POC.Webcam.js.Infra.Data.DataContexts;
using POC.Webcam.js.Infra.Data.Repositories.Queries;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Webcam.js.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _dataContext;
        private readonly DynamicParameters _parameters = new();

        public PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<long> Insert(Person person)
        {
            _parameters.Add("Name", person.Name, DbType.String);
            _parameters.Add("Birth", person.Birth, DbType.DateTime);
            _parameters.Add("Email", person.Email, DbType.String);
            _parameters.Add("Password", person.Password, DbType.String);
            _parameters.Add("Image", person.Image, DbType.String);

            return await _dataContext.Connection.ExecuteScalarAsync<long>(PersonQueries.Insert, _parameters);
        }

        public async Task Update(Person person)
        {
            _parameters.Add("Id", person.Id, DbType.Int64);
            _parameters.Add("Name", person.Name, DbType.String);
            _parameters.Add("Birth", person.Birth, DbType.DateTime);
            _parameters.Add("Email", person.Email, DbType.String);
            _parameters.Add("Password", person.Password, DbType.String);
            _parameters.Add("Image", person.Image, DbType.String);

            await _dataContext.Connection.ExecuteAsync(PersonQueries.Update, _parameters);
        }

        public async Task Delete(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            await _dataContext.Connection.ExecuteAsync(PersonQueries.Delete, _parameters);
        }

        public async Task<Person> Get(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            return (await _dataContext.Connection.QueryAsync<Person>(PersonQueries.Get, _parameters)).FirstOrDefault();
        }

        public async Task<List<Person>> List()
        {
            return (await _dataContext.Connection.QueryAsync<Person>(PersonQueries.List)).ToList();
        }
    }
}