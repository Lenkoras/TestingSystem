namespace Auth
{
    public interface IAuthenticationService<TUser>
        where TUser : IUser<Guid>
    {
        ValueTask AuthenticateAsync(TUser user);
    }
}