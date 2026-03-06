using ContactApp.API.Controllers;
using Microsoft.AspNetCore.Mvc;

public class TestController : BaseController
{
    [HttpGet("test")]
    public string GetHelloWorldText()
    {
        return "Hello world!";
    }
}

