using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var teams = _context.Nbateams.ToList();
            return Json(teams);
        }        
    }
}
