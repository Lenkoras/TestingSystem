namespace Auth.Tokens
{
    public interface ITokenService<TUser>
    {
        string CreateToken(TUser user);
    }
}
