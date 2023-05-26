using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Auth.Tokens.Jwt
{
    public class JwtTokenService<TUser, TKey> : ITokenService<TUser>
        where TUser : IUser<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly ILogger<JwtTokenService<TUser, TKey>> logger;
        private readonly TimeSpan tokenLifeTime;

        public JwtTokenService(ILogger<JwtTokenService<TUser, TKey>> logger)
        {
            this.logger = logger;
            tokenLifeTime = TimeSpan.FromDays(1);
        }

        public string CreateToken(TUser user)
        {
            JwtSecurityToken token = CreateJwtToken(CreateClaims(user));

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(tokenLifeTime),
                    signingCredentials: CreateCredentials()
                    );
        }

        private SigningCredentials CreateCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(AuthOptions.GetEncryptionKeyBytes()),
                SecurityAlgorithms.HmacSha256);

        private IEnumerable<Claim> CreateClaims(TUser user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.UserName))
                {
                    logger.LogInformation($"UserName field was empty for: {user.Id}.");
                    return Array.Empty<Claim>();
                }

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // a unique identifier for the JWT
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.NameIdentifier, user.Id?.ToString() ?? $"UnknownId:{user.UserName}"),
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                return claims;
            }
            catch (Exception e)
            {
                logger.LogError(e, $"{nameof(JwtTokenService<TUser, TKey>)}.{nameof(CreateClaims)} throws exception.");
                return Array.Empty<Claim>();
            }
        }
    }
}
