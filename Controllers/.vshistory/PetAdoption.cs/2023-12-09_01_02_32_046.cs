using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurrfectPair.Data;
using PurrfectPair.Models;

namespace PurrfectPair.Controllers
{
    public class PetAdoptionController : Controller
    {
        private readonly ILogger<PetAdoptionController> _logger;
        private readonly ApplicationDbContext _context;

        public PetAdoptionController(ILogger<PetAdoptionController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Pets pet)
        {
            if (ModelState.IsValid)
            {
                _context.Pets.Add(pet);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "ViewStatus");
                }
                catch (DbUpdateException ex)
                {
                    // Log the exception details for debugging
                    _logger.LogError(ex, "Error occurred while saving changes to the database.");

                    // Handle specific exceptions or rethrow the exception based on your needs
                    if (ex.InnerException is DbUpdateConcurrencyException)
                    {
                        // Handle concurrency exception (if needed)
                    }

                    // Rethrow the exception to propagate it to the higher level
                    throw;
                }
            }

            return View(pet);
        }
    }
}



