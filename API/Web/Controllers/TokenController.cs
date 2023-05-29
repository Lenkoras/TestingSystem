using Auth.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IDataProtector dataProtector;

        public TokenController(IDataProtectionProvider dataProtectionProvider)
        {
            this.dataProtector = dataProtectionProvider.CreateProtector(AccessTokenDefaults.ProtectorPurpouse);
        }

        [HttpPost("set")]
        [ProducesResponseType(typeof(UserAccessTokenInfo), StatusCodes.Status200OK)]
        public IActionResult SetTokenToCookies()
        {
            var values = Request.Headers[HttpRequestHeader.Authorization.ToString()];

            if (values.Count < 1)
            {
                return BadRequest("Access token not specified.");
            }
            var handler = new JwtSecurityTokenHandler();

            foreach (string? value in values)
            {
                if (value is not null)
                {
                    string token = GetTokenFromHeader(value);

                    var jsonToken = handler.ReadJwtToken(token);

                    var tokenInfo = CreateTokenInfo(jsonToken);

                    Response.Cookies.Append(
                            AccessTokenDefaults.AccessTokenKey,
                            dataProtector.Protect(token),
                            CreateCookieOptions());
                    return Ok(tokenInfo);
                }
            }
            return BadRequest("All access tokens are invalid");
        }

        private string GetTokenFromHeader(string headerValue)
        {
            ArgumentNullException.ThrowIfNull(headerValue);

            return string.Concat(headerValue.Skip(headerValue.IndexOf(' ') + 1));
        }

        private UserAccessTokenInfo CreateTokenInfo(JwtSecurityToken token)
        {
            ArgumentNullException.ThrowIfNull(token);
            
            if (!TryReadExp(token, out DateTime expirationDate))
            {
                expirationDate = EpochTime.UnixEpoch;
            }

            return new UserAccessTokenInfo(GetUserName(token), expirationDate);
        }

        private string GetUserName(JwtSecurityToken token)
        {
            return token.Claims.First(claim => claim.Type == ClaimTypes.Name)?.Value ?? "not setted";
        }

        private bool TryReadExp(JwtSecurityToken token, out DateTime expirationDate)
        {
            Claim? expClaim = token.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Exp);

            if (expClaim != null)
            {
                string exp = expClaim.Value;

                if (long.TryParse(exp, out long num))
                {
                    expirationDate = EpochTime.DateTime(num);
                    return true;
                }
            }
            expirationDate = default;
            return false;
        }

        private bool ValidateToken(JwtSecurityToken token)
        {
            ArgumentNullException.ThrowIfNull(token);

            Claim? expClaim = token.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Exp);

            if (expClaim != null)
            {
                string exp = expClaim.Value;

                if (long.TryParse(exp, out long num))
                {
                    DateTime expirationDate = EpochTime.DateTime(num);

                    if (expirationDate > DateTime.UtcNow)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        [Authorize]
        [HttpPost("get")]
        public IActionResult GetAccessToken()
        {
            return Ok(Request.Headers[HttpRequestHeader.Authorization.ToString()].FirstOrDefault());
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
