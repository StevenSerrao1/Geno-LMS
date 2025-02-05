namespace Geno_API.Entities
{
    public class FinalGrade
    {
        [Key]
        public int FinalGradeId { get; set; } // Unique Identifier for each FINALGRADE

        [Range(0, 100)]
        public double FinalScore { get; set; } // Actual final score (for whole course)(combine all grades to represent this)

        [Required]
        public int StudentId { get; set; } // Foreign key to Student

        [ForeignKey(nameof(StudentId))] // Many finalGrades can belong to one student (one for each course)
        public Student? Student { get; set; } // Navigation property for Student

        [Required]
        public int CourseId { get; set; } // Foreign key to Course        

        [ForeignKey(nameof(CourseId))] // Many finalGrades can belong to one course (one for each student)
        public Course? Course { get; set; } // Navigation property for Course
    }
}
