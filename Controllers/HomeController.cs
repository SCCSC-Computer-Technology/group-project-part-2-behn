using Azure.Core;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp2.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;


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
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null) //check if user is logged in, if not send back to login page
            {
                return RedirectToAction("Login");
            }

            return View();
        }


        public IActionResult Page2()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Page3()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Page4()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Page5()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Page6()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Page7()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NBAPage1()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NBAPage2()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NBAPage3()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NBAPage4()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NFLPage1()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NFLPage2()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NFLPage3()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult NFLPage4()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Search(string searchTerm)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

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
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(string Name, string Email, string Message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("sportsapplication206@gmail.com");
                mail.From = new MailAddress("sportsapplication206@gmail.com", "Sports Management", Encoding.UTF8);
                mail.Subject = "New Contact Form Message";
                mail.Body =
                    "<p><b>Name:</b> " + Name + "</p>" +
                    "<p><b>Email:</b> " + Email + "</p>" +
                    "<p><b>Message:</b><br>" + Message + "</p>";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential(
                        "sportsapplication206@gmail.com",
                        "tvbm affx ignj gbfu"
                    );
                    client.EnableSsl = true;

                    await client.SendMailAsync(mail);
                }

                ViewBag.SuccessMessage = "Your message has been sent successfully.";
            }
            catch
            {
                ViewBag.SuccessMessage = "There was a problem sending your message.";
            }

            return View();
        }

        public async Task<IActionResult> Favorites()
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


        public IActionResult Back()
        {
            return Redirect(Request.Headers.Referer.ToString());
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


        [HttpPost]
        public IActionResult ResetFavoriteTeams()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.User.FirstOrDefault(u => u.UserId == userId); // finds user in db based on userID in the HttpContext.Session

            if (user != null)
            {
                user.FavNflid = null;
                user.FavNbaid = null;//sets favorite teams to null
                _context.SaveChanges(); //saves changes
            }

            return RedirectToAction("User"); //refreshes page so changes are visible to user
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

        public IActionResult UpcomingEventsHTML(string category)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

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
                });

            if (!string.IsNullOrEmpty(category) && category != "ALL")
            {
                upcomingEvents = upcomingEvents.Where(e =>
                    !string.IsNullOrEmpty(e.Category) &&
                    e.Category.ToUpper() == category.ToUpper());
            }

            var filteredEvents = upcomingEvents
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

            ViewBag.SelectedCategory = category;

            return View(filteredEvents);
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

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100000);
            string code = randomNumber.ToString("D5");
           

            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "No account was found with that email.");
                return View(model);
            }

            try
            {
                if (user == null)
                {
                    ModelState.AddModelError("", "No account was found with that email.");
                    return View(model);
                }
                else
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(user.Email);
                    mail.From = new MailAddress("sportsapplication206@gmail.com", "Sports Management", Encoding.UTF8);
                    mail.Subject = "Your Sports App Password Recovery Code";
                    mail.Body = "<p>Your recovery code is: <b>" + code + "</b></p><p>Enter this code on the sports application</p>";
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;


                    using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        client.Credentials = new NetworkCredential(
                            "sportsapplication206@gmail.com",
                            "tvbm affx ignj gbfu"
                        );
                        client.EnableSsl = true;

                        await client.SendMailAsync(mail);
                    }
                    HttpContext.Session.SetString("ResetCode", code);
                    HttpContext.Session.SetString("ResetEmail", model.Email);

                    return RedirectToAction("VerifyCode");
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Email failed to send: " + ex.Message);
                return View(model);
            }

           
        }

        [HttpGet]
        public IActionResult VerifyCode()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyCode(VerifyCode model)
        {
            var storedCode = HttpContext.Session.GetString("ResetCode");
            var storedEmail = HttpContext.Session.GetString("ResetEmail");

            if (string.IsNullOrWhiteSpace(model.Code))
            {
                ModelState.AddModelError("", "Please enter the code.");
                return View(model);
            }

            if (storedCode == null || storedEmail == null)
            {
                ModelState.AddModelError("", "Your reset session expired. Please try again.");
                return RedirectToAction("ForgotPassword");
            }

            if (model.Code == storedCode)
            {
                return RedirectToAction("ResetPassword");
            }

            ModelState.AddModelError("", "Invalid code.");
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            var email = HttpContext.Session.GetString("ResetEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("ForgotPassword");
            }

            var model = new ResetPassword
            {
                Email = email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            var sessionEmail = HttpContext.Session.GetString("ResetEmail");

            if (string.IsNullOrEmpty(sessionEmail))
            {
                return RedirectToAction("ForgotPassword");
            }

            model.Email = sessionEmail;

            if (string.IsNullOrWhiteSpace(model.NewPassword))
            {
                ModelState.AddModelError("", "Please enter a new password.");
                return View(model);
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View(model);
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == sessionEmail);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(model);
            }

            user.Password = model.NewPassword;

            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("ResetCode");
            HttpContext.Session.Remove("ResetEmail");

            return RedirectToAction("Login");
        }
    }
}


