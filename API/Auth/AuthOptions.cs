using Auth.Cryptography;
using System.Text;

namespace Auth
{
    public static class AuthOptions
    {
        private static readonly string EncryptionEnviromentVariableKey = "TestingSystemEncryptionKey";

        private static readonly byte[] encryptionKeyBytes;

        /// <summary>
        /// Encryption key.
        /// </summary>
        public static byte[] EncryptionKeyBytes => encryptionKeyBytes.ToArray();

        /// <summary>
        /// Token issuer.
        /// </summary>
        public static readonly string Issuer = "TestingSystemAuthServer";

        static AuthOptions()
        {
            string? key = Environment.GetEnvironmentVariable(EncryptionEnviromentVariableKey);
            Encoding encoding = Encoding.UTF8;

            if (key is null)
            {
                char[] uniqueKeyChars = CreateEncryptionKey();

                Environment.SetEnvironmentVariable(EncryptionEnviromentVariableKey, string.Concat(uniqueKeyChars));

                encryptionKeyBytes = encoding.GetBytes(uniqueKeyChars);
            }
            else
            {
                encryptionKeyBytes = encoding.GetBytes(key);
            }
        }

        private static char[] CreateEncryptionKey()
        {
            using RandomKeyGenerator keyProvider = new RandomKeyGenerator();
            char[] uniqueKeyChars = keyProvider.CreateKey(size: 50);
            
            return uniqueKeyChars;
        }
    }
}