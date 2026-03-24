using System.Collections.Generic;

namespace SportsApp2.Models
{
    public class SearchResultsViewModel
    {
        public List<Nbateam> NbaTeams { get; set; } = new List<Nbateam>();
        public List<Nflteam> NflTeams { get; set; } = new List<Nflteam>();
    }
}