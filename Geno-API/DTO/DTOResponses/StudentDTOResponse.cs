namespace Geno_API.DTO.DTOResponses
{
    public class StudentDTOResponse
    {
        public int StudentId { get; set; }

        // Display the join date, possibly formatted if needed (or as DateTime if the client can format)
        public string? DateJoined { get; set; }

        // Instead of AdminId, return the Admin's name (or a combined profile string)
        public string? AdminName { get; set; }

        // Optionally, include additional fields from the User base class:
        public string? FirstName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

        // Optionally, summaries for relationships:
        public List<string> EnrolledCourseNames { get; set; } = new List<string>();
        public List<string> FinalGradeSummaries { get; set; } = new List<string>();
        public List<string> GradeSummaries { get; set; } = new List<string>();
        public List<string> SelectedAnswerSummaries { get; set; } = new List<string>();

    }
}
