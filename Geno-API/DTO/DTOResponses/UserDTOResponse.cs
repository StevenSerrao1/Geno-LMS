namespace Geno_API.DTO.DTOResponses
{
    public class UserDTOResponse
    {
        public int UserId { get; set; }

        public string Role { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        // You can compute FullName on the fly here, or simply copy it from the entity if already computed.
        public string FullName => string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)
            ? string.Empty
            : $"{FirstName} {LastName}";

    }
}
