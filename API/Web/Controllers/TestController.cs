using AutoMapper;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Binding.Models;
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

        [HttpPost("check")]
        [ProducesResponseType(typeof(TestCheckResultModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckTestAsync([FromBody] TestCheckModel testCheck)
        {
            var parsedTestCheck = mapper.Map<ParsedTestCheckModel>(testCheck);

            Test? test = await repositoryWrapper.Tests.FindAsync(parsedTestCheck.Id);

            if (test is null)
            {
                return NotFound("Test not found");
            }

            var parsedQuestions = parsedTestCheck.Questions.DistinctBy(parsedQuestion => parsedQuestion.Id).ToArray();

            var questions = test.TestQuestions.Where(question => parsedQuestions.Any(parsedQuestion => parsedQuestion.Id == question.Id)).ToArray();

            if (questions.Length != parsedQuestions.Length)
            {
                return BadRequest("Invalid questions count or contained duplicate values.");
            }

            int correctCount = 0;

            foreach (var question in questions)
            {
                var parsedQuestion = parsedQuestions.FirstOrDefault(parsedQuestion => parsedQuestion.Id == question.Id);

                if (parsedQuestion is null)
                {
                    return NotFound("Test question not found");
                }
                var answer = question.Answers.FirstOrDefault(answer => answer.IsCorrect);
                if (answer is not null && answer.Id == parsedQuestion.AnswerId)
                {
                    correctCount++;
                }
            }

            return Ok(new TestCheckResultModel() { CorrectCount = correctCount, TotalCount = questions.Length });
        }
    }
}
