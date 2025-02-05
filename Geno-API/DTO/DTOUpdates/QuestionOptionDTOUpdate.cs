namespace Geno_API.DTO.DTOUpdates
{
    public class QuestionOptionDTOUpdate
    {
        public int QuestionOptionId { get; set; }
        public string? QuestionText { get; set; }  // The actual question content.

        public QuestionLetterEnum? CorrectAnswer { get; set; }  // The correct answer option.

        public int QuizId { get; set; }  // Ties the question to a specific quiz.

        public List<QuestionOptionDTORequest> QuestionOptions { get; set; } = new();
    }
}
