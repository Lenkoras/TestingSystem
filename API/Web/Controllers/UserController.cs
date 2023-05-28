using AutoMapper;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Security.Claims;
using Web.Extensions;

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

            User? user;

            if (!userIdentity.TryGetId(out Guid id) ||
                (user = await repositoryWrapper.Users.FindAsync(id)) is null) /// user not found
            {
                HttpContext.Response.Cookies.DeleteAccessToken();
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
    }
}
