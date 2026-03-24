using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SportsApp2.Models
{
    public class CreateAccount
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        public IFormFile? ProfileImage { get; set; }
        public string? ProfileImagePath { get; set; }
    }
}
