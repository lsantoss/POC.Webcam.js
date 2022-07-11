using Dapper;
using POC.Webcam.js.Domain.Interfaces.Repositories;
using POC.Webcam.js.Domain.Models.Pessoa;
using POC.Webcam.js.Infra.Data.Repositories.Queries;
using POC.Webcam.js.Infra.Settings;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace POC.Webcam.js.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly SettingsDatabase _settingsDatabase;
        private readonly DynamicParameters _parametros = new DynamicParameters();

        public PessoaRepository(SettingsDatabase settingsDatabase)
        {
            _settingsDatabase = settingsDatabase;
        }

        public long Salvar(PessoaViewModel pessoa)
        {
            _parametros.Add("Nome", pessoa.Nome, DbType.String);
            _parametros.Add("DataNascimento", pessoa.DataNascimento, DbType.DateTime);
            _parametros.Add("Email", pessoa.Email, DbType.String);
            _parametros.Add("Senha", pessoa.Senha, DbType.String);
            _parametros.Add("ImagemBase64String", pessoa.ImagemBase64String, DbType.String);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                return connection.ExecuteScalar<long>(PessoaQueries.Salvar, _parametros);
            }
        }

        public void Atualizar(PessoaViewModel pessoa)
        {
            _parametros.Add("Id", pessoa.Id, DbType.Int64);
            _parametros.Add("Nome", pessoa.Nome, DbType.String);
            _parametros.Add("DataNascimento", pessoa.DataNascimento, DbType.DateTime);
            _parametros.Add("Email", pessoa.Email, DbType.String);
            _parametros.Add("Senha", pessoa.Senha, DbType.String);
            _parametros.Add("ImagemBase64String", pessoa.ImagemBase64String, DbType.String);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                connection.Execute(PessoaQueries.Atualizar, _parametros);
            }
        }

        public void Deletar(long id)
        {
            _parametros.Add("Id", id, DbType.Int64);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                connection.Execute(PessoaQueries.Deletar, _parametros);
            }
        }

        public PessoaViewModel Obter(long id)
        {
            _parametros.Add("Id", id, DbType.Int64);

            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                return connection.Query<PessoaViewModel>(PessoaQueries.Obter, _parametros).FirstOrDefault();
            }
        }

        public List<PessoaViewModel> Listar()
        {
            using (var connection = new SqlConnection(_settingsDatabase.ConnectionString))
            {
                return connection.Query<PessoaViewModel>(PessoaQueries.Listar).ToList();
            }
        }
    }
}