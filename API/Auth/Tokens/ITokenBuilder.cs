namespace Auth.Tokens
{
    public interface ITokenBuilder<TUser>
    {
        string CreateToken(TUser user);
    }
}
