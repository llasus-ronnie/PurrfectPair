using Microsoft.AspNetCore.Mvc;
using PurrfectPair.Data;
using PurrfectPair.Models;

namespace PurrfectPair.Controllers
{
    public class ViewStatusController : Controller
    {
        private readonly ILogger<ViewStatusController> _logger;
        private readonly ApplicationDbContext _context;

        public ViewStatusController(ILogger<ViewStatusController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            // Retrieve user data from the database
            var userId = HttpContext.Session.GetInt32("UserID"); // Use GetInt32 if UserID is an integer
            var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                ViewBag.User = user;
            }
            var petSubmissionModel =
                _context.PetSubmissions.Where(x => x.UserID == userId)
                .Select(x => new PetSubmissionModel
                {
                    Address = user.Address,
                    ContactNumber = user.ContactNumber,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    pet_age = x.pet_age,
                    pet_breed = x.pet_breed,
                    pet_gender = x.pet_gender,
                    pet_adopting = x.pet_is_adopting ? "X" : "",
                    pet_adoption = !x.pet_is_adopting ? "X" : "",
                    pet_name = x.pet_name,
                    pet_photos = x.pet_photos,
                    pet_submission_id = x.pet_submission_id,
                    pet_type = x.pet_type,
                    Username = user.Username
                }).ToList();

            // Pass user data to the view
            return View(petSubmissionModel);
        }

    }
}

