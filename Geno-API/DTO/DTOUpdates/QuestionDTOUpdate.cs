namespace Geno_API.DTO.DTOUpdates
{
    public class QuestionDTOUpdate
    {

        public int QuestionId { get; set; }

        public string? QuestionText { get; set; }  // The actual question content.

        public QuestionLetterEnum? CorrectAnswer { get; set; }  // The correct answer option.

        public List<QuestionOptionDTOUpdate>? QuestionOpions { get; set; }

    }
}
