namespace Geno_API.Entities
{
    public class CorrectAnswer
    {
        [Key]
        public int CorrectAnswerId { get; set; }

        [Required]
        [Range('A', 'D')]
        public char CorrectAnswerLetter { get; set; }

        [Required]
        public int QuestionId { get; set; }  // Foreign key to Question

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; } = new Question(); // Navigation property to the related Question
    }
}
