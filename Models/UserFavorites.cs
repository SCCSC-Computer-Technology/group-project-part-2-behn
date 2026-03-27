namespace SportsApp2.Models
{
    public class UserFavorites
    {
        public User User { get; set; }

        public List<Nflteam> NflTeams { get; set; } = new List<Nflteam>();
        public List<Nbateam> NbaTeams { get; set; } = new List<Nbateam>();

        public Nflteam? FavoriteNflTeam { get; set; }
        public Nbateam? FavoriteNbaTeam { get; set; }
    }

    
}
