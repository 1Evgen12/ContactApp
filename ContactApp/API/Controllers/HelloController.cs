using Microsoft.AspNetCore.Mvc;

namespace ContactApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet("hello/{name}")]
        public string GetGreetingByName(string name)
        {
            return $"Привет, {name}!";
        }
    }
}
