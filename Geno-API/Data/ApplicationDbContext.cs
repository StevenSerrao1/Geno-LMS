namespace Geno_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor to pass the DbContext options to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Create properties below (will be initialized by EFCore)
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

        // OnModelCreating method / Used to map and initialize relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Entity Mapping Region*
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
            #endregion

            #region User Relationships
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId); // Creates primary key
            });
            #endregion

            #region Admin Relationships

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(a => a.UserId); // Unique Id

                // Admin -> User
                entity.HasOne<User>() // Establish inheritance relationship
                      .WithOne()
                      .HasForeignKey<Admin>(a => a.UserId) // FK to User.Id
                      .OnDelete(DeleteBehavior.Cascade); // Cascade delete

                // Admin -> Student
                entity.HasMany(a => a.Students) // Many Students belong to One Admin
                      .WithOne(s => s.Admin) // One Admin oversees many Students
                      .HasForeignKey(s => s.AdminId) // FK to AdminId
                      .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Admin -> CREATED Course
                entity.HasMany(a => a.CreatedCourses) // Many CreatedCourses belong to One Admin
                      .WithOne(cc => cc.CreatedByAdmin) // One Admin oversees many CreatedCourses
                      .HasForeignKey(cc => cc.CreatedByAdminId) // FK to CreatedByAdminId
                      .OnDelete(DeleteBehavior.Restrict); // RESTRICT DELETE

                // Admin -> UPDATED Course
                entity.HasMany(a => a.UpdatedCourses) // Many UpdatedCourses belong to One Admin
                      .WithOne(uc => uc.UpdatedByAdmin) // One Admin oversees many UpdatedCourses
                      .HasForeignKey(uc => uc.UpdatedByAdminId) // FK to UpdatedByAdminId
                      .OnDelete(DeleteBehavior.Restrict); // RESTRICT DELETE

                // Admin -> CREATED Lesson
                entity.HasMany(a => a.CreatedLessons) // Many CreatedLessons belong to One Admin
                      .WithOne(cl => cl.CreatedByAdmin) // One Admin oversees many CreatedLessons
                      .HasForeignKey(cl => cl.CreatedByAdminId) // FK to CreatedByAdminId
                      .OnDelete(DeleteBehavior.Restrict); // RESTRICT DELETE

                // Admin -> UPDATED Lesson
                entity.HasMany(a => a.UpdatedLessons) // Many UpdatedLessons belong to One Admin
                      .WithOne(ul => ul.UpdatedByAdmin) // One Admin oversees many UpdatedLessons
                      .HasForeignKey(ul => ul.UpdatedByAdminId) // FK to UpdatedByAdminId
                      .OnDelete(DeleteBehavior.Restrict); // RESTRICT DELETE

                // Admin -> CREATED Quiz
                entity.HasMany(a => a.CreatedQuizzes) // Many CreatedQuizzes belong to One Admin
                      .WithOne(quiz => quiz.CreatedByAdmin) // One Admin oversees many CreatedQuizzes
                      .HasForeignKey(quiz => quiz.CreatedByAdminId) // FK to CreatedByAdminId
                      .OnDelete(DeleteBehavior.Restrict); // RESTRICT DELETE

                // Admin -> UPDATED Quiz
                entity.HasMany(a => a.UpdatedLessons) // Many UpdatedQuizzes belong to One Admin
                      .WithOne(quiz => quiz.UpdatedByAdmin) // One Admin oversees many UpdatedQuizzes
                      .HasForeignKey(quiz => quiz.UpdatedByAdminId) // FK to UpdatedByAdminId
                      .OnDelete(DeleteBehavior.Restrict); // RESTRICT DELETE
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

                // Student -> Admin
                entity.HasOne(s => s.Admin) // Many Students belong to one Admin
                      .WithMany(a => a.Students) // One Admin oversees many Students
                      .HasForeignKey(s => s.AdminId) // FK to AdminId
                      .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Student -> Enrolments
                entity.HasMany(s => s.Enrolments) // One Student has many Enrolments (one per course)
                      .WithOne(e => e.Student) // Many Enrolments belong to one Student 
                      .HasForeignKey(e => e.StudentId) // FK to StudentId
                      .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Student -> FinalGrades
                entity.HasMany(s => s.FinalGrades) // One Student has many Final Grades (one per course)
                      .WithOne(fg => fg.Student) // Many Final Grades belong to one Student 
                      .HasForeignKey(fg => fg.StudentId) // FK to StudentId
                      .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Student -> Grades
                entity.HasMany(s => s.Grades) // One Student has many Grades (one per quiz/lesson)
                      .WithOne(g => g.Student) // Many Grades belong to one Student 
                      .HasForeignKey(g => g.StudentId) // FK to StudentId
                      .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Student -> SelectedAnswers
                entity.HasMany(s => s.SelectedAnswers) // One Student has many Selected Answer (one per question)
                      .WithOne(sa => sa.Student) // Many SA's belong to one Student 
                      .HasForeignKey(sa => sa.StudentId) // FK to StudentId
                      .OnDelete(DeleteBehavior.Cascade); // DELETE 

                // Student Indices
                entity.HasIndex(s => s.Enrolments);
                entity.HasIndex(s => s.FinalGrades);
                entity.HasIndex(s => s.FirstName);
                entity.HasIndex(s => s.Email);

            });

            #endregion

            #region Course Relationships

            // CREATED Course -> Admin
            modelBuilder.Entity<Course>()
                .HasOne(cc => cc.CreatedByAdmin) // One Admin oversees many CreatedCourses
                .WithMany(a => a.CreatedCourses) // Many CreatedCourses belong to One Admin
                .HasForeignKey(cc => cc.CreatedByAdminId) // FK to CreatedByAdminId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

            // UPDATED Course -> Admin
            modelBuilder.Entity<Course>()
                .HasOne(uc => uc.UpdatedByAdmin) // One Admin oversees many UpdatedCourses
                .WithMany(a => a.UpdatedCourses) // Many UpdatedCourses belong to One Admin
                .HasForeignKey(uc => uc.UpdatedByAdminId) // FK to UpdatedByAdminId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

            // Course -> Enrolments
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrolments)  // A Course can have many Enrolments
                .WithOne(e => e.Course)      // An Enrolment refers to one Course
                .HasForeignKey(e => e.CourseId)  // The foreign key in Enrolment is CourseId
                .OnDelete(DeleteBehavior.Cascade);  // Optionally, you can specify what happens on delete

            // Course -> Lessons
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lessons) // A Course can have many Lessons
                .WithOne(l => l.Course) // A Lesson can belong to ONLY ONE Course
                .HasForeignKey(l => l.CourseId) // The FK in Course is LessonId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

            // Indices
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
                entity.HasOne(e => e.Student) // One Student has many enrolments
                    .WithMany(s => s.Enrolments) // Many Enrolments can belong to One Student
                    .HasForeignKey(e => e.StudentId) // FK to StudentId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Relationship: Enrolment -> Course
                entity.HasOne(e => e.Course) // One Course can have many Enrolments
                    .WithMany(c => c.Enrolments) // Many Enrolments can belong to One Student
                    .HasForeignKey(e => e.CourseId) // FK to CourseId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE
            });

            #endregion

            #region FinalGrade Relationships

            modelBuilder.Entity<FinalGrade>().HasKey(fg => fg.FinalGradeId);

            // FinalGrade -> Student
            modelBuilder.Entity<FinalGrade>()
                .HasOne(fg => fg.Student) // One FinalGrade per student
                .WithMany(s => s.FinalGrades) // One Student has many FinalGrades
                .HasForeignKey(fg => fg.StudentId) // FK to StudentId
                .OnDelete(DeleteBehavior.Cascade); // Delete related data

            // FinalGrade -> Course
            modelBuilder.Entity<FinalGrade>()
                .HasOne(fg => fg.Course) // One FinalGrade per course
                .WithMany(c => c.FinalGrades) // One Course can have many FinalGrades (one per student)
                .HasForeignKey(fg => fg.CourseId) // FK to CourseId
                .OnDelete(DeleteBehavior.Cascade); // Delete related data

            // Index FinalScore for faster retrieval
            modelBuilder
                .Entity<FinalGrade>()
                .HasIndex(fg => fg.FinalScore);

            #endregion

            #region Grade Relationships

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(grade => grade.GradeId);

                // Grade -> Student
                entity
                .HasOne(grade => grade.Student) // One Student per Grade (each Grade belongs to one Student)
                .WithMany(s => s.Grades) // One Student can have many Grades
                .HasForeignKey(grade => grade.StudentId) // FK to StudentId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Grade -> Quiz
                entity
                .HasOne(grade => grade.Quiz) // One Grade can only come from one Quiz
                .WithMany(q => q.Grades) // One Quiz can have many Grades (one per student)
                .HasForeignKey(grade => grade.QuizId) // FK to QuizId
                .OnDelete(DeleteBehavior.Cascade); // DELETE
                
                // Indices
                entity.HasIndex(g => g.GradeScore);
            });

            #endregion

            #region Lessons Relationships

            modelBuilder.Entity<Lesson>(entity =>
            {
                // Unique Id
                entity.HasKey(lesson => lesson.LessonId);

                // CREATED Lesson -> Admin
                modelBuilder.Entity<Lesson>()
                    .HasOne(cl => cl.CreatedByAdmin) // One Admin oversees many CreatedLessons
                    .WithMany(a => a.CreatedLessons) // Many CreatedLessons belong to One Admin
                    .HasForeignKey(cl => cl.CreatedByAdminId) // FK to CreatedByAdminId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // UPDATED Lesson -> Admin
                modelBuilder.Entity<Lesson>()
                    .HasOne(ul => ul.UpdatedByAdmin) // One Admin oversees many UpdatedLessons
                    .WithMany(a => a.UpdatedLessons) // Many UpdatedLessons belong to One Admin
                    .HasForeignKey(ul => ul.UpdatedByAdminId) // FK to UpdatedByAdminId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Lesson -> Course
                entity
                .HasOne(l => l.Course) // Every Lesson comes from one Course
                .WithMany(c => c.Lessons) // Every Course has multiple Lessons
                .HasForeignKey(l => l.CourseId) // FK to CourseId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Lesson -> Quiz
                entity
                .HasOne(l => l.Quiz) // Every Lesson has one Quiz
                .WithOne(q => q.Lesson) // Every Quiz is connected to only one Lesson
                .HasForeignKey<Quiz>(q => q.LessonId) // FK to LessonId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Indices
                entity.HasIndex(l => l.LessonName);
                entity.HasIndex(l => l.Description);
            });

            #endregion

            #region Question Relationships

            modelBuilder.Entity<Question>(entity =>
            {
                // Unique Id
                entity.HasKey(q => q.QuestionId);

                // Question -> Quiz
                entity
                    .HasOne(question => question.Quiz) // Each Question is connected to one Quiz
                    .WithMany(quiz => quiz.Questions) // Each Quiz can have multiple Questions
                    .HasForeignKey(question => question.QuizId) // FK to QuizId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Question -> QuestionOption (Being the four available options; 'A', 'B', 'C', 'D')
                entity
                    .HasMany(q => q.QuestionOptions) // Each Question can have 4 QuestionOptions (A, B, C, D)
                    .WithOne(qo => qo.Question) // Each QuestionOption is based on only one Question
                    .HasForeignKey(qo => qo.QuestionId) // FK to QuestionId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Index properties for querying
                entity.Property(q => q.CorrectAnswer) // CorrectAnswer stored as a property
                    .IsRequired();
            });

            #endregion

            #region QuestionOption Relationships

            modelBuilder.Entity<QuestionOption>(entity =>
            {
                // Unique Id
                entity.HasKey(qo => qo.QuestionOptionId);

                // QuestionOption -> Question
                entity
                    .HasOne(qo => qo.Question) // Each QuestionOption belongs to one Question
                    .WithMany(q => q.QuestionOptions) // Each Question can have many QuestionOptions
                    .HasForeignKey(qo => qo.QuestionId) // FK to QuestionId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE
            });

            #endregion

            #region Quiz Relationships

            modelBuilder.Entity<Quiz>(entity =>
            {
                // Unique Id
                entity.HasKey(q => q.QuizId);

                // CREATED Quiz -> Admin
                modelBuilder.Entity<Quiz>()
                    .HasOne(cq => cq.CreatedByAdmin) // One Admin oversees many CreatedQuizzes
                    .WithMany(a => a.CreatedQuizzes) // Many CreatedQuizzes belong to One Admin
                    .HasForeignKey(cq => cq.CreatedByAdminId) // FK to CreatedByAdminId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // UPDATED Quiz -> Admin
                modelBuilder.Entity<Quiz>()
                    .HasOne(uq => uq.UpdatedByAdmin) // One Admin oversees many UpdatedQuizzes
                    .WithMany(a => a.UpdatedQuizzes) // Many UpdatedQuizzes belong to One Admin
                    .HasForeignKey(uq => uq.UpdatedByAdminId) // FK to UpdatedByAdminId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Quiz -> Lesson
                entity
                .HasOne(q => q.Lesson) // Each Quiz is connected to one Lesson
                .WithOne(l => l.Quiz) // Each Lesson has only one Quiz
                .HasForeignKey<Lesson>(l => l.QuizId) // FK to QuizId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Quiz -> Grade
                entity
                .HasMany(q => q.Grades) // Each Quiz can have many grades (one per student)
                .WithOne(g => g.Quiz) // Each Grade comes from one Quiz only
                .HasForeignKey(g => g.QuizId) // FK to QuizId
                .OnDelete(DeleteBehavior.Cascade); // DELETE

                // Quiz -> Question
                entity
                .HasMany(quiz => quiz.Questions) // Each Quiz has many questions
                .WithOne(question => question.Quiz) // Each Question is connected to only one Quiz
                .HasForeignKey(question => question.QuizId) // FK to QuizId
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
                // Unique Id
                entity.HasKey(sa => sa.SelectedAnswerId);

                // SelectedAnswer -> Question
                entity
                    .HasOne(sa => sa.Question) // One SelectedAnswer belongs to one Question
                    .WithMany(q => q.SelectedAnswers) // One Question can have many SA's (one per student)
                    .HasForeignKey(sa => sa.QuestionId) // FK to QuestionId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

                // SelectedAnswer -> Student
                entity
                    .HasOne(sa => sa.Student) // One SelectedAnswer can belong to a single Student
                    .WithMany(stu => stu.SelectedAnswers) // Many Students can have a selectedanswer (one per question)
                    .HasForeignKey(sa => sa.StudentId) // FK to StudentId
                    .OnDelete(DeleteBehavior.Cascade); // DELETE

            });

            #endregion
        }
    }
}
