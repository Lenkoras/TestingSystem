using System.Security.Cryptography;

namespace Auth.Cryptography
{
    public class RandomKeyGenerator : IDisposable
    {
        private RandomNumberGenerator? randomNumberGenerator;
        public string KeySource { get; }

        public RandomKeyGenerator(string keySource)
        {
            ArgumentNullException.ThrowIfNull(keySource);

            KeySource = keySource;
            randomNumberGenerator = RandomNumberGenerator.Create();
        }

        public RandomKeyGenerator() : this(new DefaultKeySourceProvider().GetKeySource())
        {
        }

        ~RandomKeyGenerator()
        {
            Dispose(nullifyMembers: false);
        }

        public char[] GetRandomKey(int size)
        {
            const int ShiftSize = sizeof(int);

            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size),
                    $"Specified {nameof(size)} parameter for {nameof(RandomKeyGenerator)}.{nameof(GetRandomKey)} was less than zero (0).");
            }

            if ((long)size * ShiftSize > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException($"Specified {nameof(size)} parameter for {nameof(RandomKeyGenerator)}.{nameof(GetRandomKey)} have too large size. It should be less or equal than {nameof(Int32)}.{nameof(int.MaxValue)} / {ShiftSize}. ({int.MaxValue / ShiftSize})");
            }

            ObjectDisposedException.ThrowIf(randomNumberGenerator is null, this);

            byte[] data = new byte[size * ShiftSize];
            randomNumberGenerator.GetBytes(data);
            char[] key = new char[size];

            for (int i = 0; i < size; i++)
            {
                uint randomNumber = BitConverter.ToUInt32(data, i * ShiftSize);
                int characterIndex = (int)(randomNumber % KeySource.Length);

                key[i] = KeySource[characterIndex];
            }

            return key;
        }

        public void Dispose()
        {
            Dispose(nullifyMembers: true);
        }

        private void Dispose(bool nullifyMembers)
        {
            if (randomNumberGenerator != null)
            {
                randomNumberGenerator.Dispose();
                if (nullifyMembers)
                {
                    randomNumberGenerator = null;
                }
            }
        }
    }
}
