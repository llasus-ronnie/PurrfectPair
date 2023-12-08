using Microsoft.AspNetCore.Mvc;
using PurrfectPair.Data;
using PurrfectPair.Models;

namespace PurrfectPair.Controllers
{
    public class AdoptCats : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ViewStatusController> _logger;

        public AdoptCats(ILogger<ViewStatusController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var petSubmissionModel =
               _context.PetSubmissions.Where(x => x.pet_type == "Cat" && !x.pet_is_adopting)
               .Select(x => new PetSubmissionModel
               {
                   Address = _context.Users.FirstOrDefault(y => y.UserID == x.UserID).Address,
                   ContactNumber = _context.Users.FirstOrDefault(y => y.UserID == x.UserID).ContactNumber,
                   Email = _context.Users.FirstOrDefault(y => y.UserID == x.UserID).Email,
                   FirstName = _context.Users.FirstOrDefault(y => y.UserID == x.UserID).FirstName,
                   LastName = _context.Users.FirstOrDefault(y => y.UserID == x.UserID).LastName,
                   pet_age = x.pet_age,
                   pet_breed = x.pet_breed,
                   pet_gender = x.pet_gender,
                   pet_adopting = x.pet_is_adopting ? "X" : "",
                   pet_adoption = !x.pet_is_adopting ? "X" : "",
                   pet_name = x.pet_name,
                   pet_photos = x.pet_photos,
                   pet_submission_id = x.pet_submission_id,
                   pet_type = x.pet_type,
                   Username = _context.Users.FirstOrDefault(y => y.UserID == x.UserID).Username
               }).ToList();

            var groupedPets = petSubmissionModel.Select((pet, index) => new { Pet = pet, GroupIndex = index / 3 })
                          .GroupBy(x => x.GroupIndex)
                          .Select(group => group.Select(item => item.Pet)).ToList();


            return View(groupedPets);
        }
    }
}
