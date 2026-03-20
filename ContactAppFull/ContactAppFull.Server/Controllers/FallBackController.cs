using Microsoft.AspNetCore.Mvc;

namespace ContactAppFull.Server.Controllers
{
    [Route("[controller]")]
    public class FallBackController:Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return PhysicalFile(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "index.html"
                ), "text/HTML");
                
        }
    }
}
