namespace Geno_API.DTO.DTOUpdates
{
    public class UserDTOUpdate
    {
        [Required]
        public int UserId { get; set; }  // Must be provided for updating an existing record

        // Optional properties to allow partial updates
        public string? Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
