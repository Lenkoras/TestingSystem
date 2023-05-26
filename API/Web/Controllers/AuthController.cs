using Auth.Tokens;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Binding.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepositoryWrapper repositoryWrapper;
        private ITokenService<User> tokenService;
        private ILogger<AuthController> logger;

        public AuthController(IRepositoryWrapper repositoryWrapper, ITokenService<User> tokenService, ILogger<AuthController> logger)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.tokenService = tokenService;
            this.logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginInfo)
        {
            User? user = await AuthenticateUserAsync(loginInfo.UserName, loginInfo.Password);

            if (user is null)
            {
                return Unauthorized();
            }

            string token = tokenService.CreateToken(user);

            logger.LogInformation($"User {user.Email} logged in at {DateTime.Now.ToLongTimeString()}.");

            return Ok(token);
        }

        private async Task<User?> AuthenticateUserAsync(string userName, string password)
        {
            return await repositoryWrapper.Users.FirstAsync(user => user.UserName == userName);
        }
    }
}
