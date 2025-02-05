namespace Geno_API.DTO.DTOResponses
{
    public class GradeDTOResponse
    {
        public int GradeId { get; set; }

        public double GradeScore { get; set; }

        public StudentDTOResponse? Student { get; set; }

        public string? CourseName { get; set; }

        public string? QuizName { get; set; }

    }
}
