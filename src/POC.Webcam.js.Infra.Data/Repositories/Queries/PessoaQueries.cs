namespace POC.Webcam.js.Infra.Data.Repositories.Queries
{
    public static class PessoaQueries
    {
        public static string Salvar { get; } = @"INSERT INTO Pessoa 
                                                 (Nome, DataNascimento, Email, Senha, ImagemBase64String) 
                                                 VALUES 
                                                 (@Nome, @DataNascimento, @Email, @Senha, @ImagemBase64String); 
                                                 SELECT SCOPE_IDENTITY();";

        public static string Atualizar { get; } = @"UPDATE Pessoa SET 
                                                        Nome = @Nome,
                                                        DataNascimento = @DataNascimento,
                                                        Email = @Email,
                                                        Senha = @Senha,
                                                        ImagemBase64String = @ImagemBase64String
                                                    WHERE Id = @Id";

        public static string Deletar { get; } = @"DELETE FROM Pessoa WHERE Id = @Id";

        public static string Obter { get; } = @"SELECT
                                                    Id AS Id,
                                                    Nome AS Nome,
                                                    DataNascimento AS DataNascimento,
                                                    Email AS Email,
                                                    Senha AS Senha,
                                                    ImagemBase64String AS ImagemBase64String
                                                FROM Pessoa WITH(NOLOCK)
                                                WHERE Id = @Id";

        public static string Listar { get; } = @"SELECT
                                                    Id AS Id,
                                                    Nome AS Nome,
                                                    DataNascimento AS DataNascimento,
                                                    Email AS Email,
                                                    Senha AS Senha,
                                                    ImagemBase64String AS ImagemBase64String
                                                FROM Pessoa WITH(NOLOCK) 
                                                ORDER BY Id ASC";
    }
}