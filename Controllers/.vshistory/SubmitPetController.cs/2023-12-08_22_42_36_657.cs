using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using PurrfectPair.Data;
using PurrfectPair.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.IO;
using System.Threading.Tasks;


namespace PurrfectPair.Controllers
{
    public class SubmitPetController : Controller
    {
        //image upload
        private readonly IWebHostEnvironment _webHost;

        private readonly ILogger<SubmitPetController> _logger;
        private readonly ApplicationDbContext _context;

        //forms 
        //private IPetSubmissionForm _service;

        public SubmitPetController(IWebHostEnvironment webHost, ILogger<SubmitPetController> logger, ApplicationDbContext context)
        {
            _webHost = webHost;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                ViewBag.User = user;
            }
            return View(user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(PetSubmissionForm pet)
        {
            try
            {
                if (pet != null && pet.petPhoto != null )
                {
                    var userId = HttpContext.Session.GetInt32("UserID");
                    var user = _context.Users.FirstOrDefault(u => u.UserID == userId);


                    string uploadsFolder = Path.Combine(_webHost.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    IFormFile imageFile = pet.petPhoto;
                    string fileName= DateTime.Now.ToString("yyyyMMddHHmmss")+"_"+Path.GetFileName(pet.petPhoto.FileName);
                    string fileSavePath = Path.Combine(uploadsFolder, fileName);

                    using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    ViewBag.Message = fileName + "uploaded successfully";

                    _context.Add(new PetSubmission
                    {
                        pet_age = pet.pet_age,
                        pet_breed = pet.pet_breed,
                        pet_gender = pet.pet_gender,
                        pet_name = pet.pet_name,
                        pet_photos = fileName,
                        UserID = user.UserID,
                        pet_type = pet.pet_type,
                        pet_is_adopting = false
                    }); 

                    await _context.SaveChangesAsync();

                }

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message; 
            }

            return RedirectToAction(nameof(ViewStatusController.Index),"ViewStatus");

        }


    }
}
