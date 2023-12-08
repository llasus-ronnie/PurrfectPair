using Microsoft.AspNetCore.Mvc;
using PurrfectPair.Data;
using PurrfectPair.Models;
using System.Threading.Tasks;

namespace PurrfectPair.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SignUpController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    ContactNumber = model.ContactNumber,
                    Email = model.Email,
                    Address = model.Address,
                    Password = model.Password
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}





