using Microsoft.AspNetCore.Mvc;

namespace PurrfectPair.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
