namespace FormWebcamJs.Infra.Hash
{
    public static class HashHelper
    {
        public static string GerarHash(string senha, int workFactor = 11)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(senha, workFactor, BCrypt.Net.HashType.SHA384);
        }

        public static bool ValidarHash(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(senha, hash, BCrypt.Net.HashType.SHA384);
        }
    }
}