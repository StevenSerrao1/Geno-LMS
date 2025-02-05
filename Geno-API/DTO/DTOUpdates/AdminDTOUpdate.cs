namespace Geno_API.DTO.DTOUpdates
{
    public class AdminDTOUpdate
    {
        public int AdminId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [EmailAddress]
        public string? AdminEmail { get; set; }
    }
}
