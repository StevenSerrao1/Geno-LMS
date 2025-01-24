namespace Geno_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<CorrectAnswer>? CorrectAnswers { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Enrolment>? Enrolments { get; set; }
        public DbSet<FinalGrade>? FinalGrades { get; set; }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<QuestionOption>? QuestionOptions { get; set; }
        public DbSet<Quiz>? Quizzes { get; set; }
        public DbSet<SelectedAnswer>? SelectedAnswers { get; set; }

    }
}
