using Auth.Cryptography;

namespace TestingSystem.Tests
{
    public class AuthTests
    {
        [Theory]
        [InlineData(20)]
        public void GetRandomKey_ReturnsNotNullAndSameSizeArray(int keySize)
        {
            // Arrange
            var randomKeyGenerator = new RandomKeyGenerator();

            // Act
            char[]? actualKey = randomKeyGenerator.CreateKey(size: keySize);

            // Assert
            Assert.True(actualKey is not null);
            Assert.Equal(keySize, actualKey.Length);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(int.MaxValue / 4 + 1)]
        public void GetRandomKey_ThrowsArgumentOutOfRangeException(int keySize)
        {
            // Arrange
            var randomKeyGenerator = new RandomKeyGenerator();

            // Act
            Action actual = () => randomKeyGenerator.CreateKey(size: keySize);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }
    }
}