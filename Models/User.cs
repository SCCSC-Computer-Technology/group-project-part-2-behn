namespace SportsApp2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int? FavNbaid { get; set; }
        public int? FavNflid { get; set; }
        public int? FavNbaplayerId { get; set; }
        public int? FavNflplayerId { get; set; }

        public string? ProfileImagePath { get; set; }
    }
}
