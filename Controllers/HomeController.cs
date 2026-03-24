using Microsoft.AspNetCore.Mvc;
using SportsApp2.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace SportsApp2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page1()
        {
            return View();
        }


        public IActionResult Page2()
        {
            return View();
        }

        public IActionResult Page3()
        {
            return View();
        }

        public IActionResult Page4()
        {
            return View();
        }

        public IActionResult Page5()
        {
            return View();
        }

        public IActionResult Page6()
        {
            return View();
        }

        public IActionResult Page7()
        {
            return View();
        }

        public IActionResult NBAPage1()
        {
            return View();
        }

        public IActionResult NBAPage2()
        {
            return View();
        }

        public IActionResult NBAPage3()
        {
            return View();
        }

        public IActionResult NBAPage4()
        {
            return View();
        }

        public IActionResult NFLPage1()
        {
            return View();
        }

        public IActionResult NFLPage2()
        {
            return View();
        }

        public IActionResult NFLPage3()
        {
            return View();
        }

        public IActionResult NFLPage4()
        {
            return View();
        }

        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return RedirectToAction("Page1");
            }

            var nbaTeams = _context.Nbateams
                .Where(t => t.TeamName.Contains(searchTerm))
                .ToList();

            var nflTeams = _context.Nflteams
                .Where(t => t.TeamName.Contains(searchTerm))
                .ToList();

            ViewBag.SearchTerm = searchTerm;

            var model = new SearchResultsViewModel
            {
                NbaTeams = nbaTeams,
                NflTeams = nflTeams
            };

            return View(model);
        }

        //This for login
        public async Task<IActionResult> User()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }

            return View(user);
        }


        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
       

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        //This for login
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly BEHNDatabaseContext _context;

        public HomeController(BEHNDatabaseContext context)
        {
            _context = context;
        }

        //This for login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //This for login 
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("User");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(CreateAccount model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string imagePath = null;

            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(stream);
                }

                imagePath = "/images/" + fileName;
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                ProfileImagePath = imagePath
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("User");
        }


    }
}
