namespace Geno_API.Entities
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; } // Unique Identifier for each Lesson

        [Required]
        public string LessonName { get; set; } // Name of the specific lesson (e.g. C# 101)

        public string? Description { get; set; } // Description of the specific lesson

        [Required]
        public int CourseId { get; set; } // Foreign key to Course        

        [ForeignKey(nameof(CourseId))] // Many lessons can belong to one course (by nature)
        public Course? Course { get; set; } // Navigation property for Course

        public int QuizId { get; set; } // Foreign key to Quiz        

        [ForeignKey(nameof(QuizId))] // One quiz can belong to one lesson (one quiz per lesson was the decided amount, coulda been more)
        public Quiz? Quiz { get; set; } // Navigation property for Quiz

        public Lesson() // Constructor to initialize properties upon creation of object
        {
            this.LessonName = string.Empty;
        }
    }
}
