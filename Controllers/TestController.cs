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

            if (team == null)
            {
                return Content("Team not found.");
            }

            return View(team);
        }
    }
}