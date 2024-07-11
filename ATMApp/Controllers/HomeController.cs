using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public string function()
        {
            return "Hello World";
        }
    }
}
