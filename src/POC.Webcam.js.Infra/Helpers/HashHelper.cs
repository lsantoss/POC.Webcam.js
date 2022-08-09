using BCrypt.Net;

namespace POC.Webcam.js.Infra.Helpers
{
    public static class HashHelper
    {
        private const HashType _hashType = HashType.SHA384;

        public static string GenerateHash(string text, int workFactor = 11)
        {
            if (text == null)
                return null;

            return BCrypt.Net.BCrypt.EnhancedHashPassword(text, workFactor, _hashType);
        }

        public static bool ValidateHash(string text, string hash)
        {
            if(text == null || hash == null)
                return false;

            return BCrypt.Net.BCrypt.EnhancedVerify(text, hash, _hashType);
        }
    }
}