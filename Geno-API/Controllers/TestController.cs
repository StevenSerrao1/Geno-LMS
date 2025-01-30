using Geno_API.Backend_Tests;
using Geno_API.Data;
using Geno_API.Entities.Users;
using Geno_API.Entities;
using System.Collections.Generic;

namespace Geno_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("seed-data")]
        public IActionResult SeedData()
        {
            // Create SeedDataMultiClass object to test validity of ALL entities at once (non-dto)
            SeedDataMultiClass seedDataMultiClass = new SeedDataMultiClass()
            {
                users = new(),
                admins = new(),
                students = new(),
                courses = new(),
                enrolments = new(),
                finalgrades = new()
            };

            // Check null values and assign each value to the context value 
            if (_context.Users is not null && _context.Admins is not null && _context.Students is not null && _context.Courses is not null && _context.Enrolments is not null && _context.FinalGrades is not null)
            {

                seedDataMultiClass.users = _context.Users.ToList();
                seedDataMultiClass.admins = _context.Admins.ToList();
                seedDataMultiClass.students = _context.Students.ToList();
                seedDataMultiClass.courses = _context.Courses.ToList();
                seedDataMultiClass.enrolments = _context.Enrolments.ToList();
                seedDataMultiClass.finalgrades = _context.FinalGrades.ToList();

                seedDataMultiClass.teststring = "";

                foreach (User user in seedDataMultiClass.users)
                {
                    seedDataMultiClass.teststring += $"User FullName: {user.FullName}\nRole: {user.Role}\nEmail: {user.Email}\nDOB: {user.DateOfBirth}\n\n";
                }

                foreach (Student student in seedDataMultiClass.students)
                {
                    seedDataMultiClass.teststring += $"Student Enrolment: {student.Enrolments.ToArray()[0].EnrolmentId}\nDate Joined: {student.DateJoined.ToShortDateString()}\nAdmin Full Name: {student.Admin?.FullName}\nStudent Name: {student.FullName}\nEnrolment Course Name: {student.Enrolments.ToArray()[0].Course?.Title.ToString()}\nFinalGrade: {student.Enrolments.ToArray()[0].Course?.FinalGrades.ToArray()[0].FinalScore}\n\n";
                }

                foreach (Enrolment enrol in seedDataMultiClass.enrolments)
                {
                    seedDataMultiClass.teststring += $"Enrolment Id: {enrol.EnrolmentId}\nStudent Enroled: {enrol.Student?.FullName}\nCourse Enroled in: {enrol.Course?.Title}\nDate Enroled: {enrol.EnrolmentDate.ToShortDateString()}\n\n";
                }

                foreach (Course c in seedDataMultiClass.courses)
                {
                    seedDataMultiClass.teststring += $"Course Id: {c.CourseId}\nDate Created: {c.CreatedDate.ToShortDateString()}\nTitle: {c.Title}\nDescription: {c.Description}\nStudents Enroled: {c.Enrolments.ToArray()[1].Student?.FullName}\n\n";
                }

                foreach (FinalGrade fg in seedDataMultiClass.finalgrades)
                {
                    seedDataMultiClass.teststring += $"FG Id: {fg.FinalGradeId}\nFinal Score: {fg.FinalScore}\nTitle of course: {fg.Course?.Title}\nStudent Name: {fg.Student?.FullName}\n\n";
                }
            }

            return Ok(seedDataMultiClass.teststring);
        }
    }
}
