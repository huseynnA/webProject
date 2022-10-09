using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
      //[Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult Products() 
        {
            return View();
        }
    }
}
