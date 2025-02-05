namespace Geno_API.DTO.DTOResponses
{
    public class QuizDTOResponse
    {
        public int QuizId { get; set; }

        public string? QuizName { get; set; }

        public string? QuizDescription { get; set; }

        public uint PassingScore { get; set; }

        public uint MaxScore { get; set; }

        public string? CreatedByAdmin { get; set; } // Display admin name instead of ID

        public string? UpdatedByAdmin { get; set; } // If updated, show the admin's name

        public int? LessonId { get; set; }

        public List<QuestionDTOResponse> Questions { get; set; } = new();

    }
}
