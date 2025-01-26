using System.ComponentModel.DataAnnotations;

namespace Geno_API.Entities.Users
{
    public class User // SUPERCLASS
    {
        [Key]
        public int UserId { get; set; } // Unique StudentId (to be inherited by all subtypes)

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; } = string.Empty; // User's First Name

        [Required]
        [StringLength(150)]
        public string LastName { get; set; } = string.Empty; // User's Last Name

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty; // User's email address

        [Required]
        public DateTime DateOfBirth { get; set; } // User's date of birth

        [StringLength(300)]
        public string? FullName // Assembly of First + Last Name properties
        {
            get => string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)
                ? null // Return null if either FirstName or LastName is missing
                : FirstName + " " + LastName;
        }
    }
}
