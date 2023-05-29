namespace Auth.Tokens
{
    public class TokenOptions : ITokenOptions
    {
        public TimeSpan LifeTime { get; }

        public TokenOptions(TimeSpan lifeTime)
        {
            LifeTime = lifeTime;
        }
    }
}
