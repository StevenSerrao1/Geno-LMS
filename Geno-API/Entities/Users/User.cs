using System.ComponentModel.DataAnnotations;

namespace Geno_API.Entities.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string LastName { get; set; } = string.Empty; // User's Last Name

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty; // User's email address

        [Required]
        public DateTime DateOfBirth { get; set; } // User's date of birth

        [StringLength(300)]
        public string? FullName
        {
            get => string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)
                ? null // Return null if either FirstName or LastName is missing
                : FirstName + " " + LastName;
        }
    }
}
