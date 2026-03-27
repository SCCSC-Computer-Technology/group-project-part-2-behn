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
                { "Bulls", "w3-vivid-red" },
                { "Celtics", "w3-green" },
                { "Heat", "w3-crimson" },
                { "Warriors", "w3-amber" },
                { "Knicks", "w3-orange" },
                { "Nets", "w3-black" },
                { "Mavericks", "w3-light-blue" },
                { "Rockets", "w3-food-cherry" },
                { "Clippers", "w3-blue-grey" },
                { "Thunder", "w3-light-blue" },
                { "Suns", "w3-orange" },
                { "Kings", "w3-deep-purple" },
                { "Timberwolves", "w3-info" },
                { "Spurs", "w3-black" },
                { "Pelicans", "w3-food-coffee" },
                { "Hornets", "w3-vivid-greenish-blue" },
                { "Pistons", "w3-blue" },
                { "Pacers", "w3-vivid-yellow" },
                { "Raptors", "w3-highway-red" },
                { "76ers", "w3-signal-blue" },
                { "Bucks", "w3-signal-green" },
                { "Magic", "w3-blue" },
                { "Jazz", "w3-deep-purple" },
                { "Wizards", "w3-food-strawberry" },
                { "Hawks", "w3-red" },
                { "Blazers", "w3-red" },
                { "Cavaliers", "w3-food-wine" },
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

            var teamColors = new Dictionary<string, string>
            {   
                { "Cardinals", "w3-food-cranberry" },
                { "Falcons", "w3-vivid-red" },
                { "Ravens", "w3-vivid-purplish-blue" },
                { "Bills", "w3-info" },
                { "Panthers", "w3-blue" },
                { "Bears", "w3-vivid-reddish-orange" },
                { "Bengals", "w3-vivid-orange" },
                { "Browns", "w3-food-chocolate" },
                { "Cowboys", "w3-highway-blue" },
                { "Broncos", "w3-vivid-reddish-orange" },
                { "Lions", "w3-blue" },
                { "Packers", "w3-highway-green" },
                { "Texans", "w3-signal-blue" },
                { "Colts", "w3-info" },
                { "Jaguars", "w3-vivid-bluish-green" },
                { "Chiefs", "w3-food-cherry" },
                { "Raiders", "w3-black" },
                { "Chargers", "w3-blue" },
                { "Rams", "w3-food-lemon" },
                { "Dolphins", "w3-teal" },
                { "Vikings", "w3-purple" },
                { "Patriots", "w3-signal-blue" },
                { "Saints", "w3-food-coffee" },
                { "Giants", "w3-highway-blue" },
                { "Jets", "w3-highway-green" },
                { "Eagles", "w3-vivid-bluish-green" },
                { "Steelers", "w3-vivid-yellow" },
                { "49ers", "w3-vivid-red" },
                { "Seahawks", "w3-food-apple" },
                { "Buccaneers", "w3-danger" },
                { "Titans", "w3-light-blue" },
                { "Commanders", "w3-highway-red" }
            };

            ViewBag.TeamColors = teamColors;

            return View(team);
        }


    }
}