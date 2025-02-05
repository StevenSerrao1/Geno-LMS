namespace Geno_API.DTO.DTORequests
{
    public class UserDTORequest
    {
        [Required]
        public string Role { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
