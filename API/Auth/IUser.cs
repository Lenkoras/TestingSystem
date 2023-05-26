namespace Auth
{
    public interface IUser<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets the primary key for this user.
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Gets the user name for this user.
        /// </summary>
        string? UserName { get; }
    }
}
