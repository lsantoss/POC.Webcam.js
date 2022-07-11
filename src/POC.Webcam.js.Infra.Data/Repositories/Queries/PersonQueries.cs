namespace POC.Webcam.js.Infra.Data.Repositories.Queries
{
    public static class PersonQueries
    {
        public static string Insert { get; } = @"INSERT INTO Person 
                                                 (Name, Birth, Email, Password, Image) 
                                                 VALUES 
                                                 (@Name, @Birth, @Email, @Password, @Image); 
                                                 SELECT SCOPE_IDENTITY();";

        public static string Update { get; } = @"UPDATE Person SET 
                                                        Name = @Name,
                                                        Birth = @Birth,
                                                        Email = @Email,
                                                        Password = @Password,
                                                        Image = @Image
                                                    WHERE Id = @Id";

        public static string Delete { get; } = @"DELETE FROM Person WHERE Id = @Id";

        public static string Get { get; } = @"SELECT
                                                    Id AS Id,
                                                    Name AS Name,
                                                    Birth AS Birth,
                                                    Email AS Email,
                                                    Password AS Password,
                                                    Image AS Image
                                                FROM Person WITH(NOLOCK)
                                                WHERE Id = @Id";

        public static string List { get; } = @"SELECT
                                                    Id AS Id,
                                                    Name AS Name,
                                                    Birth AS Birth,
                                                    Email AS Email,
                                                    Password AS Password,
                                                    Image AS Image
                                                FROM Person WITH(NOLOCK) 
                                                ORDER BY Id ASC";
    }
}