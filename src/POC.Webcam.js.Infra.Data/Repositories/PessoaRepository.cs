using Dapper;
using POC.Webcam.js.Domain.Person.Entities;
using POC.Webcam.js.Domain.Person.Interfaces.Repositories;
using POC.Webcam.js.Infra.Data.Repositories.Queries;
using POC.Webcam.js.Infra.Settings;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Webcam.js.Infra.Data.Repositories
{
    public class PessoaRepository : IPersonRepository
    {
        private readonly SettingsDatabase _settingsDatabase;
        private readonly DynamicParameters _parametros = new DynamicParameters();

        public PessoaRepository(SettingsDatabase settingsDatabase)
        {
            _settingsDatabase = settingsDatabase;
        }

        public async Task<long> Insert(Person pessoa)
        {
            _parametros.Add("Nome", pessoa.Name, DbType.String);
            _parametros.Add("DataNascimento", pessoa.Birth, DbType.DateTime);
            _parametros.Add("Email", pessoa.Email, DbType.String);
            _parametros.Add("Senha", pessoa.Password, DbType.String);
            _parametros.Add("ImagemBase64String", pessoa.Image, DbType.String);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                return connection.ExecuteScalar<long>(PessoaQueries.Salvar, _parametros);
            }
        }

        public async Task Update(Person pessoa)
        {
            _parametros.Add("Id", pessoa.Id, DbType.Int64);
            _parametros.Add("Nome", pessoa.Name, DbType.String);
            _parametros.Add("DataNascimento", pessoa.Birth, DbType.DateTime);
            _parametros.Add("Email", pessoa.Email, DbType.String);
            _parametros.Add("Senha", pessoa.Password, DbType.String);
            _parametros.Add("ImagemBase64String", pessoa.Image, DbType.String);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                connection.Execute(PessoaQueries.Atualizar, _parametros);
            }
        }

        public async Task Delete(long id)
        {
            _parametros.Add("Id", id, DbType.Int64);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                connection.Execute(PessoaQueries.Deletar, _parametros);
            }
        }

        public async Task<Person> Get(long id)
        {
            _parametros.Add("Id", id, DbType.Int64);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                return connection.Query<Person>(PessoaQueries.Obter, _parametros).FirstOrDefault();
            }
        }

        public async Task<List<Person>> List()
        {
            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                return connection.Query<Person>(PessoaQueries.Listar).ToList();
            }
        }
    }
}