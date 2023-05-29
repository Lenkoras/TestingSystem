namespace Auth.Tokens
{
    public interface ITokenInfo
    {
        string Content { get; }

        DateTime ExpiresIn { get; }
    }
}
