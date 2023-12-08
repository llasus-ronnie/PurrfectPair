using Microsoft.AspNetCore.Mvc;

namespace PurrfectPair.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
