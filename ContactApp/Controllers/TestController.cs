using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public string GetHelloWorldText()
        {
            return "Hello world!";
        }
    }

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
