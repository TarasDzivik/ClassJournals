using Microsoft.AspNetCore.Mvc;

namespace ClassJournals.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
