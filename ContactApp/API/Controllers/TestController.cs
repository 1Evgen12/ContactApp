using Microsoft.AspNetCore.Mvc;

namespace ContactApp.API.Controllers
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
}
