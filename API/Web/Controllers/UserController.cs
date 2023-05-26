using Auth.Tokens;
using AutoMapper;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public UserController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet("tests")]
        [ProducesResponseType(typeof(UserTestShort[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserTestsAsync()
        {
            var userIdentity = this.User;

            string? textId = userIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (textId is null || !Guid.TryParse(textId, out Guid id))
            {
                RemoveTokenFromCookies();
                return Unauthorized();
            }

            User? user = await repositoryWrapper.Users.FindAsync(id);

            if (user is null)
            {
                RemoveTokenFromCookies();
                return Unauthorized();
            }

            UserTestShort[] tests = user.Tests.Select(mapper.Map<UserTestShort>).ToArray();

            return Ok(tests);
        }

        [Authorize]
        [HttpGet("info")]
        public IActionResult GetUserInfo()
        {
            return Ok(new
            {
                Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                UserName = User.FindFirst(ClaimTypes.Name)?.Value
            });
        }

        private void RemoveTokenFromCookies()
        {
            HttpContext.Response.Cookies.Delete(
                AccessTokenDefaults.AccessTokenKey,
                new CookieOptions()
                {
                    HttpOnly = true,
                    Secure = true
                }
            );
        }
    }
}
