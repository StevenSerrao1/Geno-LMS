namespace Geno_API.Entities.Users
{
    public class Student : User
    {
        #region Properties

        // Capture the date that the student SIGNS UP INITIALLY
        public DateTime DateJoined { get; set; }
        public int? AdminId { get; set; } // Foreign Key to Admin

        public Admin? Admin { get; set; } // Navigation Property to Admin

        // One student can have many enrolments (one student to many courses*)
        public List<Enrolment> Enrolments { get; set; } // Navigation Property to Enrolment

        // One student can have many final grades (one per course)
        public List<FinalGrade> FinalGrades { get; set; } // Navigation Property to FinalGrade

        // One student can have many grades (one per quiz)
        public List<Grade> Grades { get; set; } // Navigation Property to Grade

        // One student can have many selected answers (one per question per quiz)
        public List<SelectedAnswer> SelectedAnswers { get; set; } // Navigation Property for SelectedAnswer

        #endregion

        public Student()
        {           
            this.DateJoined = DateTime.UtcNow; // Initialize date that student joined Geno
            this.Enrolments = new List<Enrolment>(); // Initialize Enrolments list
            this.FinalGrades = new List<FinalGrade>(); // Initialize FinalGrades list
            this.Grades = new List<Grade>(); // Initialize Grades list
            this.SelectedAnswers = new List<SelectedAnswer>();
        }
    }
}
