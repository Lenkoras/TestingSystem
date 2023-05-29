namespace Auth.Tokens
{
    public interface ITokenOptions
    {
        TimeSpan LifeTime { get; }
    }
}
