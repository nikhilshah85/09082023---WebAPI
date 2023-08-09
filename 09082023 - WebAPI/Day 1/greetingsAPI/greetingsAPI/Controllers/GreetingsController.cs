using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace greetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {

        [HttpGet]
        [Route("/greetings")]
        public IActionResult Greetings()
        {
            return Ok("Hello and welcome to WebAPI development world");
        }
    }
}
