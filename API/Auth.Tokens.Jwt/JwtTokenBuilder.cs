using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Auth.Tokens.Jwt
{
    public class JwtTokenBuilder<TUser, TKey> : ITokenBuilder<TUser>
        where TUser : IUser<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly ILogger<JwtTokenBuilder<TUser, TKey>> logger;
        private readonly ITokenOptions tokenOptions;
        private readonly JwtSecurityTokenHandler tokenHandler;
        private readonly SigningCredentials signingCredentials;

        public JwtTokenBuilder(ITokenOptions tokenOptions, ILogger<JwtTokenBuilder<TUser, TKey>> logger)
        {
            this.tokenOptions = tokenOptions;
            this.logger = logger;
            this.tokenHandler = new JwtSecurityTokenHandler();
            this.signingCredentials = CreateCredentials();
        }

        public ITokenInfo CreateToken(TUser user)
        {
            DateTime expires = DateTime.UtcNow.Add(tokenOptions.LifeTime);

            JwtSecurityToken token = CreateJwtSecurityToken(CreateClaims(user), expires);

            return new TokenInfo(tokenHandler.WriteToken(token), expires);
        }

        private JwtSecurityToken CreateJwtSecurityToken(IEnumerable<Claim> claims, DateTime expires)
        {
            return new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    claims: claims,
                    expires: expires,
                    signingCredentials: signingCredentials
                    );
        }

        private static SigningCredentials CreateCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(AuthOptions.EncryptionKeyBytes),
                SecurityAlgorithms.HmacSha256);

        private IEnumerable<Claim> CreateClaims(TUser user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                logger.LogInformation($"UserName field was empty for: {user.Id}.");
                return Array.Empty<Claim>();
            }

            var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // a unique identifier for the JWT
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.NameIdentifier, user.Id?.ToString() ?? $"Unknown id for:{user.UserName}"),
                    new Claim(ClaimTypes.Name, user.UserName)
                };
            return claims;
        }
    }
}
