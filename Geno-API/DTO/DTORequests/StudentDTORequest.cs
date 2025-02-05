namespace Geno_API.DTO.DTORequests
{
    public class StudentDTORequest
    {

        [Required]
        public int? AdminId { get; set; }

        public List<int> CourseIDs { get; set; } = new();

        public List<int> FinalGradeIDs { get; set; } = new();

        public List<int> GradeIDs { get; set; } = new();

        public List<int> SelectedAnswerIDs { get; set; } = new();

    }
}
