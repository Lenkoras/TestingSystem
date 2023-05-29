namespace Shared.Models
{
    public class UserAccessTokenInfo
    {
        public string UserName { get; set; }
        /// <summary>
        /// Expiration date in UTC started from <see cref="DateTime.UnixEpoch"></see>.
        /// </summary>
        public long ExpiresIn { get; set; }

        public UserAccessTokenInfo(string? userName, DateTime expiresIn) :
            this(userName, FormatToMillisecondsStartedFromUnixEpoch(expiresIn))
        {
        }

        public UserAccessTokenInfo(string? userName, long expiresIn)
        {
            UserName = userName ?? string.Empty;
            ExpiresIn = expiresIn;
        }

        private static long FormatToMillisecondsStartedFromUnixEpoch(DateTime expiresIn)
        {
            return (long)expiresIn.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
        }
    }
}
