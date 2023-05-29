using Auth;
using Auth.Tokens;
using Database.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace Logic.Services
{
    public class AccessTokenAuthenticationService : IAuthenticationService<User>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDataProtector dataProtector;
        private readonly ITokenBuilder<User> tokenBuilder;

        private IResponseCookies Cookies => httpContextAccessor.HttpContext?.Response.Cookies ??
            throw new InvalidOperationException($"Cannot set value to cookies because the {nameof(HttpContext)} property returned null, but it's invalid behaviour for the {nameof(IHttpContextAccessor)}.");

        public AccessTokenAuthenticationService(IHttpContextAccessor httpContextAccessor, IDataProtectionProvider dataProtectionProvider, ITokenBuilder<User> tokenBuilder)
        {
            this.httpContextAccessor = httpContextAccessor;
            dataProtector = dataProtectionProvider.CreateProtector(AccessTokenDefaults.ProtectorPurpouse);
            this.tokenBuilder = tokenBuilder;
        }

        public ValueTask<ITokenInfo> AuthenticateAsync(User user)
        {
            ITokenInfo tokenInfo = tokenBuilder.CreateToken(user);

            AddToken(tokenInfo.Content);

            return ValueTask.FromResult(tokenInfo);
        }

        private void AddToken(string token)
        {
            string encryptedToken = dataProtector.Protect(token);

            Cookies.Append(AccessTokenDefaults.AccessTokenKey, encryptedToken, CreateCookieOptions());
        }

        private CookieOptions CreateCookieOptions()
        {
            return new CookieOptions()
            {
                HttpOnly = true,
                Secure = true
            };
        }
    }
}
