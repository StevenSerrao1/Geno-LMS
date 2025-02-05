namespace Geno_API.DTO.DTOUpdates
{
    public class StudentDTOUpdate
    {
        [Required]
        public int StudentId { get; set; }  // The unique identifier for the student
        
        public int? AdminId { get; set; }

        // Include other updatable properties from the User base class 
        // (like Name, Email, etc.)
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
