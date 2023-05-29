using Auth;
using Auth.Tokens;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Binding.Models;
using Shared.Models;
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
        [ProducesResponseType(typeof(UserAccessTokenInfo), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginInfo)
        {
            User? user = await authorizationService.AuthorizeAsync(loginInfo.UserName, loginInfo.Password);

            if (user is null)
            {
                return NotFound("User not found"); /// about the reason why 404 code is returned here – https://stackoverflow.com/questions/5604816
            }

            ITokenInfo tokenInfo = await authenticationService.AuthenticateAsync(user);

            logger.LogInformation($"User {user.UserName} logged in at {DateTime.Now.ToLongTimeString()}.");

            return Ok(new UserAccessTokenInfo(user.UserName, tokenInfo.ExpiresIn));
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.DeleteAccessToken();
            return Ok();
        }
    }
}
