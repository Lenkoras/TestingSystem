using Auth;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Binding.Models;
using Web.Extensions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService<User> authorizationService;
        private readonly IAuthenticationService<User> authenticationService;
        private readonly ILogger<AuthController> logger;

        public AuthController(IAuthorizationService<User> authorizationService, IAuthenticationService<User> authenticationService, ILogger<AuthController> logger)
        {
            this.authorizationService = authorizationService;
            this.authenticationService = authenticationService;
            this.logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginInfo)
        {
            User? user = await authorizationService.AuthorizeAsync(loginInfo.UserName, loginInfo.Password);

            if (user is null)
            {
                return Unauthorized();
            }

            await authenticationService.AuthenticateAsync(user);

            logger.LogInformation($"User {user.Email} logged in at {DateTime.Now.ToLongTimeString()}.");

            return Ok();
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.DeleteAccessToken();
            return Ok();
        }
    }
}
