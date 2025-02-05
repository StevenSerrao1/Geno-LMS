namespace Geno_API.Entities
{
    public class QuestionOption // Signifies the various options available in a question regardless of correctness or being selected
    {
        [Key]
        public int QuestionOptionId { get; set; } // Unique identifier for QuestionOption

        [Required]
        public QuestionLetterEnum QuestionOptionLetter { get; set; } // Char that question option signifies

        public string? AnswerText { get; set; } // The actual answer text (e.g., "5", "8", "9", "11")

        [Required]
        public int QuestionId { get; set; } // Foreign Key to Question

        [ForeignKey(nameof(QuestionId))] // Many question options can belong to one Question (4 options)
        public Question? Question { get; set; } // Navigation property for Question
    }
}
