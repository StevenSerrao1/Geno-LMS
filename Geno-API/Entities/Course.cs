namespace Geno_API.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; } // Unique identifier for course

        [Required]
        public string Title { get; set; } = ""; // TITLE of course (is required)

        public string? Description { get; set; } // DESCRIPTION of course (is not required)

        public DateTime CreatedDate { get; set; } // DATE that course is created

        [Required]
        public int AdminId { get; set; } // Foreign Key to Admin (allowing Admin access to a course)

        [ForeignKey(nameof(AdminId))] // Many courses can be accessed/modified by the Admin
        public Admin? Admin { get; set; } // Navigation Property to Admin

        // One course can have many enrolments (one per student)
        public ICollection<Enrolment> Enrolments { get; set; } // Navigation Property to Enrolments

        // One course can have many final grades (one per student)
        public ICollection<FinalGrade> FinalGrades { get; set; } // Navigation Property to FinalGrade

        // One course can have many grades (many per student)
        public ICollection<Grade> Grades { get; set; } // Navigation Property to Grade

        // One course can have many lessons (by nature)
        public ICollection<Lesson> Lessons { get; set; } // Navigation Property to Lesson

        public Course()
        {
            this.Enrolments = new List<Enrolment>();
            this.FinalGrades = new List<FinalGrade>();
            this.Lessons = new List<Lesson>();
            this.Grades = new List<Grade>();
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
