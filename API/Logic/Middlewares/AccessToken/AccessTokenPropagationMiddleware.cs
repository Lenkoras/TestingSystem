using Auth.Tokens;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Logic.Middlewares.AccessToken
{
    public class AccessTokenPropagationMiddleware : IMiddleware
    {
        private static readonly string AuthorizationHeaderKey = HttpRequestHeader.Authorization.ToString();
        private static readonly string AccessTokenAuthenticationScheme = "Bearer";

        private IDataProtector dataProtector;

        public AccessTokenPropagationMiddleware(IDataProtectionProvider dataProtectionProvider)
        {
            dataProtector = dataProtectionProvider.CreateProtector(AccessTokenDefaults.ProtectorPurpouse);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.ContainsKey(AuthorizationHeaderKey) &&
                context.Request.Cookies.TryGetValue(AccessTokenDefaults.AccessTokenKey, out var encryptedToken) &&
                encryptedToken is not null)
            {
                string token = dataProtector.Unprotect(encryptedToken);

                context.Request.Headers.Add(AuthorizationHeaderKey, $"{AccessTokenAuthenticationScheme} {token}");
            }

            await next.Invoke(context);
        }
    }
}