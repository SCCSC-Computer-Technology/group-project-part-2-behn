using Microsoft.AspNetCore.Mvc;
using SportsApp2.Models;
using System.Diagnostics;
using System.Linq;

namespace SportsApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly BEHNDatabaseContext _context;

        public HomeController(BEHNDatabaseContext context)
        {
            _context = context;
        }

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

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}