﻿namespace Geno_API.Entities
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; } // Unique Identifier for each grade

        public double GradeScore { get; set; } // Actual score for the grade (will be combined to make finalgrade)

        [Required]
        public int StudentId { get; set; } // Foreign key to Student

        [ForeignKey(nameof(StudentId))] // Many grades can belong to one student (one per quiz)
        public Student? Student { get; set; } // Navigation property for Student

        public int? CourseId { get; set; } // Foreign key to Course        

        [ForeignKey(nameof(CourseId))] // Many grades can belong to one course (one per quiz[per lesson, per student])
        public Course? Course { get; set; } // Navigation property for Course

        public int? QuizId { get; set; } // Foreign key to Quiz        

        [ForeignKey(nameof(QuizId))] // Many grades can belong to one quiz (one per student)
        public Quiz? Quiz { get; set; } // Navigation property for Quiz
    }
}
