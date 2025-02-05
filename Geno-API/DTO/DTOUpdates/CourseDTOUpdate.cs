namespace Geno_API.DTO.DTOUpdates
{
    public class CourseDTOUpdate
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<StudentDTOUpdate>? StudentIds { get; set; }
        public List<FinalGradeDTOUpdate>? FinalGradeIds { get; set; }
        public List<GradeDTOUpdate>? GradeIds { get; set; }
        public List<LessonDTOUpdate>? LessonIds { get; set; }
    }
}
