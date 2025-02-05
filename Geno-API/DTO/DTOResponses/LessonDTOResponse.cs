namespace Geno_API.DTO.DTOResponses
{
    public class LessonDTOResponse
    {
        public int LessonId { get; set; }

        public string? LessonName { get; set; }

        public string? Description { get; set; }

        public CourseDTOResponse? Course { get; set; }

        public QuizDTOResponse? Quiz { get; set; }

    }
}
