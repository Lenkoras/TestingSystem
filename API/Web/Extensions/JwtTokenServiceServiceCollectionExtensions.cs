using Auth;
using Auth.Tokens;
using Auth.Tokens.Jwt;

namespace Web.Extensions
{
    public static class JwtTokenServiceServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtTokenService<TUser>(this IServiceCollection services)
            where TUser : IUser<Guid>
        {
            return AddJwtTokenService<TUser, Guid>(services);
        }

        public static IServiceCollection AddJwtTokenService<TUser, TKey>(this IServiceCollection services)
            where TUser : IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            ArgumentNullException.ThrowIfNull(services);

            return services.AddSingleton<ITokenService<TUser>, JwtTokenService<TUser, TKey>>();
        }
    }
}
