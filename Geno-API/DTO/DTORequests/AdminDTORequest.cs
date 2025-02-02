namespace Geno_API.DTO.DTORequests
{
    public class AdminDTORequest
    {
        public int AdminId { get; set; }
        public string? AdminName { get; set; }
        public DateTime? DateJoined { get; set; }

        public List<int>? CreatedCourseIds { get; set; }
        public List<int>? UpdatedCourseIds { get; set; }

        public List<int>? CreatedLessonIds { get; set; }
        public List<int>? UpdatedLessonIds { get; set; }

        public List<int>? CreatedQuizIds { get; set; }
        public List<int>? UpdatedQuizIds { get; set; }

        public List<int>? StudentIds { get; set; } = new();

    }
}
