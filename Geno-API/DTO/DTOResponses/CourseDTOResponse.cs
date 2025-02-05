namespace Geno_API.DTO.DTOResponses
{
    public class CourseDTOResponse
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedByAdminName { get; set; }
        public string? UpdatedByAdminName { get; set; }
        public List<string> StudentNames { get; set; } = new(); // Enrolment does not warrant its own DTO, simply retrieve info so
        public List<string> StudentEmails { get; set; } = new(); // Enrolment does not warrant its own DTO, simply retrieve info so
        public List<string> FinalGradeScores { get; set; } = new(); // Corresponds to the Score prop in FinalGrade entity
        public List<string> GradeScores { get; set; } = new(); // Corresponds to the Score prop in Grade entity
        public List<string> LessonNames { get; set; } = new(); // Corresponds with LessonName prop in Lesson entity

    }
}
