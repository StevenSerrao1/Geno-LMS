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

        [ForeignKey(nameof(QuizId))] // One quiz can belong to one lesson (one quiz per lesson was the decided amount)
        public Quiz? Quiz { get; set; } // Navigation property for Quiz

        [Required]
        public int CreatedByAdminId { get; set; } // Foreign Key to Admin (allowing Admin access to a lesson)

        [ForeignKey(nameof(CreatedByAdminId))] // Many courses can be CREATED by the Admin
        public Admin? CreatedByAdmin { get; set; } // Navigation Property to Admin

        // ABOVE is used to create the Lesson / BELOW is used to update the Lesson

        public int UpdatedByAdminId { get; set; } // Foreign Key to Admin (allowing Admin access to a lesson)

        [ForeignKey(nameof(UpdatedByAdminId))] // Many courses can be ACCESSED/MODIFIED by the Admin
        public Admin? UpdatedByAdmin { get; set; } // Navigation Property to Admin

        public Lesson() // Constructor to initialize properties upon creation of object
        {
            this.LessonName = string.Empty;
        }
    }
}
