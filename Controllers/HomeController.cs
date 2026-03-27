using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp2.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;


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

        [HttpPost]
        public IActionResult SaveFavoriteNfl(int teamId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.User.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                user.FavNflid = teamId;
                _context.SaveChanges();
            }

            return RedirectToAction("User");
        }

            
        

        [HttpPost]
        public IActionResult SaveFavoriteNba(int teamId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.User.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                user.FavNbaid = teamId;
                _context.SaveChanges();
            }

            return RedirectToAction("User");
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
        private readonly IWebHostEnvironment _environment;



        public HomeController(BEHNDatabaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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

        public IActionResult UpcomingEventsHTML()
        {
            List<UpcomingEvents> events = new List<UpcomingEvents>();

            string filePath = Path.Combine(_environment.ContentRootPath, "Data", "AllUpcomingEvents.xlsx");

            if (System.IO.File.Exists(filePath))
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        
                        DateTime eventDate;

                        
                        bool validDate = DateTime.TryParse(row.Cell(6).GetValue<string>(), out eventDate);

                        if (validDate)
                        {
                            events.Add(new UpcomingEvents
                            {
                                Time = row.Cell(1).GetValue<string>(),
                                Team1 = row.Cell(2).GetValue<string>(),
                                Team2 = row.Cell(3).GetValue<string>(),
                                whereToListen = row.Cell(4).GetValue<string>(),
                                Arena = row.Cell(5).GetValue<string>(),
                                Date = eventDate,
                                Category = row.Cell(7).GetValue<string>()
                            });
                        }

                    }
                }
            }

            var upcomingEvents = events
            .Where(e =>
            {
                string cleanedTime = e.Time.Replace("ET", "").Trim();

                if (DateTime.TryParse($"{e.Date:yyyy-MM-dd} {cleanedTime}", out DateTime eventDateTime))
                {
                    return eventDateTime >= DateTime.Now;
                }

                return false;
            })
            .OrderBy(e =>
            {
                string cleanedTime = e.Time.Replace("ET", "").Trim();

                if (DateTime.TryParse($"{e.Date:yyyy-MM-dd} {cleanedTime}", out DateTime eventDateTime))
                {
                    return eventDateTime;
                }

                return DateTime.MaxValue;
            })
            .ToList();

        return View(upcomingEvents);
       }

        public async Task<IActionResult> EditAccount()
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

            var model = new EditAccount
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CurrentProfileImagePath = user.ProfileImagePath
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccount(EditAccount model)
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

            if (!ModelState.IsValid)
            {
                model.CurrentProfileImagePath = user.ProfileImagePath;
                return View(model);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                user.Password = model.NewPassword;
            }

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

                user.ProfileImagePath = "/images/" + fileName;
            }

            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("User");
        }
    }
}


