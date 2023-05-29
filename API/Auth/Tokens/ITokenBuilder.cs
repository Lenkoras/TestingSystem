namespace Auth.Tokens
{
    public interface ITokenBuilder<TUser>
    {
        ITokenInfo CreateToken(TUser user);
    }
}
