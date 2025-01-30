using System.ComponentModel.DataAnnotations;

namespace Geno_API.Entities.Users
{
    public class User // SUPERCLASS
    {
        [Key]
        public int UserId { get; set; } // Unique UserId (to be inherited by all subtypes)

        [Required]
        public string Role { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; } // User's First Name

        [Required]
        [StringLength(150)]
        public string LastName { get; set; } // User's Last Name

        [Required]
        [EmailAddress]
        public string Email { get; set; } // User's email address

        [Required]
        public DateTime DateOfBirth { get; set; } // User's date of birth

        [StringLength(300)]
        public string? FullName // Assembly of First + Last Name properties
        {
            get => string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)
                ? null // Return null if either FirstName or LastName is missing
                : FirstName + " " + LastName;
        }

        public User()
        {
            Role = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }
    }
}
