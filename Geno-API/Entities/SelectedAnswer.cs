namespace Geno_API.Entities
{
    public class SelectedAnswer
    {
        [Key]
        public int SelectedAnswerId { get; set; }

        [Required]
        [Range('A', 'D')]
        public char SelectedAnswerLetter { get; set; }

        public bool IsCorrect { get; set; } // Bool for checking correctness of answer

        [Required]
        public int QuestionId { get; set; } // Foreign Key to Question

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; } = new Question(); // Navigation property to the related Question

        [Required]
        public int StudentId { get; set; } // Foreign Key to Student

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = new Student(); // Navigation property to the related Student
    }
}
