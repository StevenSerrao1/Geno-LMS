namespace Geno_API.DTO.DTORequests
{
    public class AdminDTORequest
    {
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string LastName { get; set; } = string.Empty;

    }
}
