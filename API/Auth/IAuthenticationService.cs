using Auth.Tokens;

namespace Auth
{
    public interface IAuthenticationService<TUser>
        where TUser : IUser<Guid>
    {
        ValueTask<ITokenInfo> AuthenticateAsync(TUser user);
    }
}