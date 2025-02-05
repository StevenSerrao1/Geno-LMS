namespace Geno_API.DTO.DTORequests
{
    public class LessonDTORequest
    {

        public string? LessonName { get; set; }

        public string? Description { get; set; }

        public int CourseId { get; set; } // Used to connect lesson to course?

        public int QuizId { get; set; } // Connecting quiz to lesson?

    }
}
