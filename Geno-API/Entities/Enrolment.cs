using Geno_API.Entities.Users;

namespace Geno_API.Entities
{
    public class Enrolment
    {
        [Key]
        public int EnrolmentId { get; set; } // Unique/Primary Key

        // Capture the Enrolment date when a student enrols for a course
        public DateTime EnrolmentDate { get; set; }

        [Required]
        public int UserId { get; set; } // Foreign key to Student

        [ForeignKey(nameof(UserId))] // Many enrolments can belong to one student
        public Student? Student { get; set; } // Navigation property for Student

        [Required]
        public int CourseId { get; set; } // Foreign key to Course        

        [ForeignKey(nameof(CourseId))] // Many enrolments can belong to one course
        public Course? Course { get; set; } // Navigation property for Course

        public Enrolment()
        {
            this.EnrolmentDate = DateTime.UtcNow;
        }
    }
}
