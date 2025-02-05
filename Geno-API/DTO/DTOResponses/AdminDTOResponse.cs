namespace Geno_API.DTO.DTOResponses
{
    public class AdminDTOResponse
    {
        public int AdminId { get; set; }

        public string? AdminName { get; set; }

        public string? DateJoined { get; set; }

        public List<string>? CreatedCourseNames { get; set; }
        public List<string>? UpdatedCourseNames { get; set; }

        public List<string>? CreatedLessonNames { get; set; }
        public List<string>? UpdatedLessonNames { get; set; }

        public List<string>? CreatedQuizNames { get; set; }
        public List<string>? UpdatedQuizNames { get; set; }

        public List<string>? StudentNames { get; set; }
        public List<string>? StudentEmails { get; set; }
    }
}
