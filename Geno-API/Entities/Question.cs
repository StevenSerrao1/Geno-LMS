namespace Geno_API.Entities
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; } // Unique Identifier of Question

        [Required]
        public string QuestionText { get; set; } // Question content (the actual question)

        [Required] 
        public int QuizId { get; set; } // Foreign Key to Quiz (Connecting a question to a particular quiz)

        [ForeignKey(nameof(QuizId))] // Many question can belong to one quiz (by nature)
        public Quiz? Quiz { get; set; } // Navigation Property to Quiz

        [Required]
        public int CorrectAnswerId { get; set; } // Foreign Key to CorrectAnswer (Connecting a correct answer to a particular question)

        [ForeignKey(nameof(CorrectAnswerId))] // One question can have one correct answer ONLY (by nature)
        public CorrectAnswer? CorrectAnswer { get; set; } // Navigation Property to CorrectAnswer

        public int SelectedAnswerId { get; set; } // Foreign Key to SelectedAnswer (Stating that an answer has been selected)

        [ForeignKey(nameof(SelectedAnswerId))] // One question can have one selected answer only (by multiple choice nature)
        public SelectedAnswer? SelectedAnswer { get; set; } // Navigation Property to SelectedAnswer

        // One question can have 4 different options ('A', 'B', 'C', 'D')
        public ICollection<QuestionOption> QuestionOptions { get; set; } // Navigation Property to QuestionOption

        public Question() // Constructor to initialize properties upon creation of object
        {
            this.QuestionText = string.Empty;
            this.QuestionOptions = Enum.GetValues(typeof(QuestionLetterEnum))
                .Cast<QuestionLetterEnum>()
                .Select(letter => new QuestionOption
                {
                    QuestionOptionLetter = letter
                })
                .ToList();
            // The purpose of the above assignment is to populate each question with only 4 QuestionOptions
            // each corresponding to a letter in the QuestionLetterEnum
        }
    }
}
