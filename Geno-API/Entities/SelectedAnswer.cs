namespace Geno_API.Entities
{
    public class SelectedAnswer
    {
        [Key]
        public int SelectedAnswerId { get; set; } // Unique identifier for the Selected Answer

        [Required]
        public QuestionLetterEnum SelectedAnswerLetter { get; set; } // Signifies the char value of the selected answer

        public bool IsCorrect { get; set; } // Bool for checking correctness of answer

        [Required]
        public int QuestionId { get; set; } // Foreign Key to Question

        [ForeignKey(nameof(QuestionId))] // One question can have one selected answer (at a time)
        public Question Question { get; set; } = new Question(); // Navigation property to the related Question

        [Required]
        public int StudentId { get; set; } // Foreign Key to Student

        [ForeignKey(nameof(StudentId))] // One student can have many selected answers (one per question, per quiz)
        public Student Student { get; set; } = new Student(); // Navigation property to the related Student
    }
}
