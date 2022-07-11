using BCrypt.Net;

namespace POC.Webcam.js.Infra.Helpers
{
    public static class HashHelper
    {
        private const HashType _hashType = HashType.SHA384;

        public static string GenerateHash(string password, int workFactor = 11)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor, _hashType);
        }

        public static bool ValidateHash(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash, _hashType);
        }
    }
}