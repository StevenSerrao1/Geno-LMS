namespace Geno_API.DTO.DTOUpdates
{
    public class QuizDTOUpdate
    {

        [Required]
        public int QuizId { get; set; }  // Required for identifying which quiz to update

        [Required]
        [MaxLength(100)]
        public string QuizName { get; set; } = string.Empty;

        [MaxLength(1200)]
        public string? QuizDescription { get; set; }

        [Range(1, 100)]
        public uint PassingScore { get; set; }

        [Range(1, 100)]
        public uint MaxScore { get; set; }

        public int UpdatedByAdminId { get; set; }  // The admin modifying the quiz

        public int? LessonId { get; set; }  // If the quiz is linked to a lesson

    }
}
