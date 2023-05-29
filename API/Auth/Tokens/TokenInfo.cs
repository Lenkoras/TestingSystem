namespace Auth.Tokens
{
    public class TokenInfo : ITokenInfo
    {
        public string Content { get; }
        public DateTime ExpiresIn { get; }

        public TokenInfo(string content, DateTime expiresIn)
        {
            Content = content;
            ExpiresIn = expiresIn;
        }
    }
}
