using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class RegisterUserInput
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Avatar { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
