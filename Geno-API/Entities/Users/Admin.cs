namespace Geno_API.Entities.Users
{
    public class Admin : User
    {
        #region Properties
        public DateTime DateJoined { get; set; }

        // Admin -> Course (CREATE and UPDATE)
        public ICollection<Course> CreatedCourses { get; set; }
        public ICollection<Course> UpdatedCourses { get; set; }

        // Admin -> Lesson (CREATE and UPDATE)
        public ICollection<Lesson> CreatedLessons { get; set; }
        public ICollection<Lesson> UpdatedLessons { get; set; }

        // Admin -> Quiz (CREATE and UPDATE)
        public ICollection<Quiz> CreatedQuizzes { get; set; }
        public ICollection<Quiz> UpdatedQuizzes { get; set; }

        // Admin -> Student (MONITOR)
        public ICollection<Student> Students { get; set; }

        #endregion

        public Admin()
        {
            this.CreatedCourses = new HashSet<Course>();
            this.UpdatedCourses = new HashSet<Course>();
            this.CreatedLessons = new HashSet<Lesson>();
            this.UpdatedLessons = new HashSet<Lesson>();
            this.CreatedQuizzes = new HashSet<Quiz>();
            this.UpdatedQuizzes = new HashSet<Quiz>();
            this.DateJoined = DateTime.UtcNow;
            this.Students = new HashSet<Student>();
        }
    }
}
