namespace Geno_API.DTO.DTORequests
{
    public class QuizDTORequest
    {

        [Required]
        [MaxLength(100)]
        public string QuizName { get; set; } = string.Empty;

        [MaxLength(1200)]
        public string? QuizDescription { get; set; }

        [Range(1, 100)]
        public uint PassingScore { get; set; } = 50;

        [Range(1, 100)]
        public uint MaxScore { get; set; } = 100;

        public int CreatedByAdminId { get; set; } // The admin creating the quiz

        public int? LessonId { get; set; } // If the quiz is linked to a lesson

    }
}
