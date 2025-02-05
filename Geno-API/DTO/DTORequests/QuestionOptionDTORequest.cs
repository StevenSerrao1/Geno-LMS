namespace Geno_API.DTO.DTORequests
{
    public class QuestionOptionDTORequest
    {

        public QuestionLetterEnum QuestionOptionLetter { get; set; }

        public string? AnswerText { get; set; }

        public int QuestionId { get; set; }

    }
}
