namespace Geno_API.Entities
{
    public class Quiz
    {

        [Key]
        public int QuizId { get; set; } // Unique Identifier for Quiz

        [Required]
        [MaxLength(100)]
        public string QuizName { get; set; } // Formal name of the Quiz (e.g. C# 101 Quiz)

        [MaxLength(1200)]
        public string? QuizDescription { get; set; } // Description of Quiz content if applicable

        public uint PassingScore { get; set; } // Indicates the required score to pass the quiz (50)

        public uint MaxScore { get; set; } // Indicates the Maximum score achievable for a quiz (100)

        [Required]
        public int LessonId { get; set; } // Foreign Key for Lesson

        [ForeignKey(nameof(LessonId))] // One quiz belongs to one lesson (many quizzes belong to many lessons)
        public Lesson? Lesson { get; set; } // Navigation Property for Lesson

        [Required]
        public int GradeId { get; set; } // Foreign Key for Grade

        [ForeignKey(nameof(GradeId))] // One quiz belongs to one lesson (many quizzes belong to many lessons)
        public Grade? Grade { get; set; } // Navigation Property for Grade

        // One quiz can have many questions
        public ICollection<Question> Questions { get; set; } // Navigation property to questions

        public Quiz()
        {
            this.Questions = new List<Question>();
            this.QuizName = string.Empty;
            this.MaxScore = 100;
            this.PassingScore = 50;
        }

    }
}
