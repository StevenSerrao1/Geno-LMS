namespace Geno_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor to pass the DbContext options to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Enrolment>? Enrolments { get; set; }
        public DbSet<FinalGrade>? FinalGrades { get; set; }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<QuestionOption>? QuestionOptions { get; set; }
        public DbSet<Quiz>? Quizzes { get; set; }
        public DbSet<SelectedAnswer>? SelectedAnswers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users"); // Map Users to a new table 
            modelBuilder.Entity<Student>().ToTable("Students"); // Map Students to a new table
            modelBuilder.Entity<Course>().ToTable("Courses"); // Map Courses to a new table
            modelBuilder.Entity<Enrolment>().ToTable("Enrolments"); // Map Enrolments to a new table
            modelBuilder.Entity<FinalGrade>().ToTable("FinalGrades"); // Map FinalGrades to a new table
            modelBuilder.Entity<Grade>().ToTable("Grades"); // Map Grades to a new table
            modelBuilder.Entity<Lesson>().ToTable("Lessons"); // Map Lessons to a new table
            modelBuilder.Entity<Question>().ToTable("Questions"); // Map Questions to a new table
            modelBuilder.Entity<QuestionOption>().ToTable("QuestionOptions"); // Map QO to a new table
            modelBuilder.Entity<Quiz>().ToTable("Quizzes"); // Map Quizzes to a new table
            modelBuilder.Entity<SelectedAnswer>().ToTable("SelectedAnswers"); // Map SA to a new table

            #region User Relationships
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId); // Creates primary key
            });
            #endregion

            #region Student Relationships

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.UserId);

                // Student -> User
                entity.HasOne<User>() // Establish inheritance relationship
                      .WithOne()
                      .HasForeignKey<Student>(s => s.UserId) // FK to User.Id
                      .OnDelete(DeleteBehavior.Cascade); // Cascade delete

                // Student -> Enrolment
                entity.HasIndex(s => s.Enrolments);
                entity.HasIndex(s => s.FirstName);
                entity.HasIndex(s => s.Email);

            });

            #endregion

            #region Course Relationships

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrolments)  // A Course can have many Enrolments
                .WithOne(e => e.Course)      // An Enrolment refers to one Course
                .HasForeignKey(e => e.CourseId)  // The foreign key in Enrolment is CourseId
                .OnDelete(DeleteBehavior.Cascade);  // Optionally, you can specify what happens on delete

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(c => c.Title);
                entity.HasIndex(c => c.Description);
            });

            #endregion

            #region Enrolment Relationships

            // Many-to-Many: Student <-> Course (Enrolment as join table)
            modelBuilder.Entity<Enrolment>(entity =>
            {
                // Define unique EnrolmentId as the primary key
                entity.HasKey(e => e.EnrolmentId);

                // Define composite key for StudentId and CourseId (unique per user-course pair)
                entity.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique();

                // Define foreign key relationships / Relationship: Enrolment -> Student
                entity.HasOne(e => e.Student)
                    .WithMany(s => s.Enrolments)
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Enrolment -> Course
                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Enrolments)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            #endregion

            #region FinalGrade Relationships

            modelBuilder.Entity<FinalGrade>().HasKey(fg => fg.FinalGradeId);

            // FinalGrade -> Student
            modelBuilder.Entity<FinalGrade>()
                .HasOne(fg => fg.Student) // One FinalGrade per student
                .WithMany(s => s.FinalGrades) // One Student has many FinalGrades
                .OnDelete(DeleteBehavior.Cascade); // Delete related data

            // FinalGrade -> Course
            modelBuilder.Entity<FinalGrade>()
                .HasOne(fg => fg.Course) // One FinalGrade per course
                .WithMany(c => c.FinalGrades) // One Course can have many FinalGrades (one per student)
                .OnDelete(DeleteBehavior.Cascade); // Delete related data

            modelBuilder.Entity<FinalGrade>().HasIndex(fg => fg.FinalScore);

            #endregion

            #region Grade Relationships

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(grade => grade.GradeId);

                // Grade -> Student
                entity
                .HasOne(grade => grade.Student) // One Student per Grade (each Grade belongs to one Student)
                .WithMany(s => s.Grades) // One Student can have many Grades
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Grade -> Quiz
                entity
                .HasOne(grade => grade.Quiz) // One Grade can only come from one Quiz
                .WithMany(q => q.Grades) // One Quiz can have many Grades (one per student)
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                entity.HasIndex(g => g.GradeScore);
            });

            #endregion

            #region Lessons Relationships

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(lesson => lesson.LessonId);

                // Lesson -> Course
                entity
                .HasOne(l => l.Course) // Every Lesson comes from one Course
                .WithMany(c => c.Lessons) // Every Course has multiple Lessons
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Lesson -> Quiz
                entity
                .HasOne(l => l.Quiz) // Every Lesson has one Quiz
                .WithOne(q => q.Lesson) // Every Quiz is connected to only one Lesson
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                entity.HasIndex(l => l.LessonName);
                entity.HasIndex(l => l.Description);
            });

            #endregion

            #region Question Relationships

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(q => q.QuestionId);

                // Question -> Quiz
                entity
                    .HasOne(question => question.Quiz) // Each Question is connected to one Quiz
                    .WithMany(quiz => quiz.Questions) // Each Quiz can have multiple Questions
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Question -> QuestionOption (Being the four available options; 'A', 'B', 'C', 'D')
                entity
                    .HasMany(q => q.QuestionOptions) // Each Question can have 4 QuestionOptions (A, B, C, D)
                    .WithOne(qo => qo.Question) // Each QuestionOption is based on only one Question
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Index properties for querying
                entity.Property(q => q.CorrectAnswer) // CorrectAnswer stored as a property
                    .IsRequired();
            });

            #endregion

            #region QuestionOption Relationships

            modelBuilder.Entity<QuestionOption>(entity =>
            {
                entity.HasKey(qo => qo.QuestionOptionId);

                // QuestionOption -> Question
                entity
                .HasOne(qo => qo.Question) // Each QuestionOption belongs to one Question
                .WithMany(q => q.QuestionOptions) // Each Question can have many QuestionOptions
                .OnDelete(DeleteBehavior.Cascade); // DELETE
            });

            #endregion

            #region Quiz Relationships

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(q => q.QuizId);

                // Quiz -> Lesson
                entity
                .HasOne(q => q.Lesson) // Each Quiz is connected to one Lesson
                .WithOne(l =>l.Quiz) // Each Lesson has only one Quiz
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Quiz -> Grade
                entity
                .HasMany(q => q.Grades) // Each Quiz can have many grades (one per student)
                .WithOne(g => g.Quiz) // Each Grade comes from one Quiz only
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Quiz -> Question
                entity
                .HasMany(quiz => quiz.Questions) // Each Quiz has many questions
                .WithOne(question => question.Quiz) // Each Question is connected to only one Quiz
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Index certain props for faster querying
                entity.HasIndex(q => q.PassingScore); 
                entity.HasIndex(q => q.MaxScore);
                entity.HasIndex(q => q.QuizName);

            });

            #endregion

            #region SelectedAnswer Relationships

            modelBuilder.Entity<SelectedAnswer>(entity =>
            {
                entity.HasKey(sa => sa.SelectedAnswerId);

                // SelectedAnswer -> Question
                entity
                .HasOne(sa => sa.Question) // One SelectedAnswer belongs to one Question
                .WithMany(q => q.SelectedAnswers) // One Question can have many SA's (one per student)
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // SelectedAnswer -> Student
                entity
                .HasOne(sa => sa.Student) // One SelectedAnswer can belong to a single Student
                .WithMany(stu => stu.SelectedAnswers) // Many Students can have a selectedanswer (one per question)
                .OnDelete(DeleteBehavior.Cascade);

            });

            #endregion

        }


    }
}
