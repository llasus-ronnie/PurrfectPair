using Microsoft.AspNetCore.Mvc;

namespace PurrfectPair.Controllers
{
    public class PetSelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
