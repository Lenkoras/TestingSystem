using Auth;
using Auth.Tokens;
using Auth.Tokens.Jwt;
using Database.Models;
using Logic.Middlewares.AccessToken;
using Logic.Services;

namespace Web.Extensions
{
    public static class AuthServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            /// AuthenticationBuilder
            services.AddJwtAuthentication();

            /// IdentityBuilder
            services.AddIdentityUser();

            return services.AddHttpContextAccessor()
                .AddScoped<AccessTokenPropagationMiddleware>()
                .AddScoped<IAuthorizationService<User>, ApplicationAuthorizationService>()
                .AddScoped<IAuthenticationService<User>, AccessTokenAuthenticationService>()
                .AddSingleton<ITokenBuilder<User>, JwtTokenBuilder<User, Guid>>()
                .AddAuthorization();
        }
    }
}