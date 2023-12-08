using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using PurrfectPair.Data;
using PurrfectPair.Models;
using System;
using System.Linq;

namespace PurrfectPair.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                    }
                }

                var user = _context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                Console.WriteLine($"User found: {user != null}");

                if (user != null)
                {
                    ViewBag.User = user;

                    HttpContext.Session.SetInt32("UserID", user.UserID);
                    HttpContext.Session.SetString("Username", $"{user.FirstName} {user.LastName}");
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("ContactNumber", user.ContactNumber);
                    HttpContext.Session.SetString("Address", user.Address);

                    return RedirectToAction("Index", "ViewStatus");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                }

                return View(user);
            }
            return View(model);
        }
    }
}





