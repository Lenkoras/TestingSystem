using Auth.Cryptography;
using System.Text;

namespace Auth
{
    public static class AuthOptions
    {
        private static readonly string EncryptionEnviromentVariableKey = "TestingSystemEncryptionKey";
        private static readonly char[] SecurityKeyChars;

        /// <summary>
        /// Token issuer.
        /// </summary>
        public static readonly string Issuer = "TestingSystemAuthServer";

        static AuthOptions()
        {
            string? key = Environment.GetEnvironmentVariable(EncryptionEnviromentVariableKey);

            SecurityKeyChars = key?.ToCharArray() ?? GenerateNewEncryptionKeyAndSetToEnvironment();
        }

        /// <summary>
        /// Encryption key.
        /// </summary>
        public static byte[] GetEncryptionKeyBytes() =>
            Encoding.UTF8.GetBytes(SecurityKeyChars);

        private static char[] GenerateNewEncryptionKeyAndSetToEnvironment()
        {
            using RandomKeyGenerator keyProvider = new RandomKeyGenerator();
            char[] uniqueKeyChars = keyProvider.GetRandomKey(size: 50);
            string key = string.Concat(uniqueKeyChars);
            Environment.SetEnvironmentVariable(EncryptionEnviromentVariableKey, key);
            return uniqueKeyChars;
        }
    }
}