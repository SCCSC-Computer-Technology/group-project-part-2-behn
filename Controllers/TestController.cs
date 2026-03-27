using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp2.Models;

namespace SportsApp2.Controllers
{
    public class TestController : Controller
    {
        private readonly BEHNDatabaseContext _context;

        public TestController(BEHNDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult TeamPlayers(int id)
        {
            var team = _context.Nbateams
                .Include(t => t.Nbaplayers)
                .FirstOrDefault(t => t.NbateamId == id);

            var teamColors = new Dictionary<string, string>
            {
                { "Lakers", "w3-deep-purple" },
                { "Bulls", "w3-red" },
                { "Celtics", "w3-green" },
                { "Heat", "w3-crimson" },
                { "Warriors", "w3-amber" },
                { "Knicks", "w3-orange" },
                { "Nets", "w3-black" },
                { "Mavericks", "w3-light-blue" },
                { "Rockets", "w3-red" },
                { "Clippers", "w3-blue-grey" },
                { "Thunder", "w3-light-blue" },
                { "Suns", "w3-orange" },
                { "Kings", "w3-deep-purple" },
                { "Timberwolves", "w3-info" },
                { "Spurs", "w3-black" },
                { "Pelicans", "w3-info" },
                { "Hornets", "w3-teal" },
                { "Pistons", "w3-blue" },
                { "Pacers", "w3-yellow" },
                { "Raptors", "w3-red" },
                { "76ers", "w3-blue" },
                { "Bucks", "w3-green" },
                { "Magic", "w3-blue" },
                { "Jazz", "w3-deep-purple" },
                { "Wizards", "w3-red" },
                { "Hawks", "w3-red" },
                { "Blazers", "w3-red" },
                { "Cavaliers", "w3-crimson" },
                { "Grizzlies", "w3-asphalt" },
                { "Nuggets", "w3-amber" }
            };

            ViewBag.TeamColors = teamColors;



            if (team == null)
            {
                return Content("Team not found.");
            }

            return View(team);
        }
        
        //Nfl filtering for players
        public IActionResult NFLTeamPlayers(int id)
        {
            var team = _context.Nflteams
                .Include(t => t.Nflplayers)
                .FirstOrDefault(t => t.NflteamId == id);

            return View(team);
        }


    }
}