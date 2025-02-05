namespace Geno_API.DTO.DTOResponses
{
    public class QuestionOptionDTOResponse
    {
        public int QuestionOptionId { get; set; }  // Unique ID of the question

        public string? QuestionText { get; set; }  // The actual question content

        public QuestionLetterEnum CorrectAnswer { get; set; }  // The correct answer option

        public int QuizId { get; set; }  // The quiz this question belongs to

        public List<QuestionOptionDTOResponse> QuestionOptions { get; set; } = new();

    }
}
