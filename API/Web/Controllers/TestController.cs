using AutoMapper;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Web.Extensions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public TestController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet("{testId}")]
        [ProducesResponseType(typeof(TestQuestionShort[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuestionsAsync([FromRoute] string testId)
        {
            if (!Guid.TryParse(testId, out Guid id))
            {
                return BadRequest();
            }

            Test? userTest = await repositoryWrapper.Tests.FindAsync(id);

            if (userTest is null)
            {
                return NotFound();
            }

            if (!User.TryGetId(out Guid userId))
            {
                HttpContext.Response.Cookies.DeleteAccessToken();
                return Unauthorized();
            }

            if (!userTest.Users.Any(user => user.Id == userId)) /// user doesn't have rights to get info about this test
            {
                return Forbid();
            }

            TestQuestionShort[] testQuestions = userTest.TestQuestions.Select(mapper.Map<TestQuestionShort>).ToArray();

            return Ok(testQuestions);
        }
    }
}
