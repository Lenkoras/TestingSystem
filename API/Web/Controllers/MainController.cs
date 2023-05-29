using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public MainController()
        {
        }

        [HttpGet]
        [HttpGet("Home")]
        [HttpGet("Tests")]
        [HttpGet("Tests/{id}")]
        [HttpGet("User")]
        [HttpGet("Auth")]
        public IActionResult SendIndexFile()
        {
            return File("~/index.html", "text/html");
        }
    }
}
