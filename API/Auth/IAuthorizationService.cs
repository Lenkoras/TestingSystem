namespace Auth
{
    public interface IAuthorizationService<TUser>
        where TUser : IUser<Guid>
    {
        ValueTask<TUser?> AuthorizeAsync(string userName, string password);
    }
}