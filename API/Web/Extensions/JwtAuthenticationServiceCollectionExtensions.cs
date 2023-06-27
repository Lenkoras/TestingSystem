using Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Web.Extensions
{
    public static class JwtAuthenticationServiceCollectionExtensions
    {
        public static AuthenticationBuilder AddJwtAuthentication(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer((JwtBearerOptions options) =>
                {
                    options.TokenValidationParameters = CreateTokenValidationParameters();
                });
        }

        private static TokenValidationParameters CreateTokenValidationParameters() =>
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = AuthOptions.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(AuthOptions.EncryptionKeyBytes),
            };
    }
}