using Microsoft.AspNetCore.Mvc;

namespace WebApplication11
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("./Views/Index.cshtml");
        }
    }
}
