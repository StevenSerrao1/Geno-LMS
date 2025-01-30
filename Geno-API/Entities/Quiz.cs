namespace Geno_API.Entities
{
    public class Quiz
    {
        #region Properties

        [Key]
        public int QuizId { get; set; } // Unique Identifier for Quiz

        [Required]
        [MaxLength(100)]
        public string QuizName { get; set; } // Formal name of the Quiz (e.g. C# 101 Quiz)

        [MaxLength(1200)]
        public string? QuizDescription { get; set; } // Description of Quiz content if applicable

        public uint PassingScore { get; set; } // Indicates the required score to pass the quiz (50)

        public uint MaxScore { get; set; } // Indicates the Maximum score achievable for a quiz (100)

        public int? CreatedByAdminId { get; set; } // Foreign Key to Admin (allowing Admin access to a Quiz)

        [ForeignKey(nameof(CreatedByAdminId))] // Many courses can be CREATED by the Admin
        public Admin? CreatedByAdmin { get; set; } // Navigation Property to Admin

        // ABOVE is used to create the Quiz / BELOW is used to update the Quiz

        public int? UpdatedByAdminId { get; set; } // Foreign Key to Admin (allowing Admin access to a Quiz)

        [ForeignKey(nameof(UpdatedByAdminId))] // Many courses can be ACCESSED/MODIFIED by the Admin
        public Admin? UpdatedByAdmin { get; set; } // Navigation Property to Admin

        public Lesson? Lesson { get; set; } // Navigation Property for Lesson
        
        // One quiz can have many grades (one per student)
        public ICollection<Grade> Grades { get; set; }

        // One quiz can have many questions
        public ICollection<Question> Questions { get; set; } // Navigation property to questions

        #endregion

        public Quiz()
        {
            this.Questions = new List<Question>();
            this.Grades = new List<Grade>();
            this.QuizName = string.Empty;
            this.MaxScore = 100;
            this.PassingScore = 50;
        }

    }
}
