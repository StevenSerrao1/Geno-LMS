namespace Geno_API.Entities
{
    public class CorrectAnswer
    {
        [Key]
        public int CorrectAnswerId { get; set; } // Unique identifier for the CorrectAnswer

        [Required]
        public QuestionLetterEnum CorrectAnswerLetter { get; set; } // Signifies the char value of the correct answer

        [Required]
        public int QuestionId { get; set; }  // Foreign key to Question

        [ForeignKey(nameof(QuestionId))] // One correct answer can belong to one question
        public Question Question { get; set; } = new Question(); // Navigation property to the related Question
    }
}
