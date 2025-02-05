namespace Geno_API.DTO.DTORequests
{
    public class QuestionDTORequest
    {
        public string? QuestionText { get; set; }  // The actual question content.

        public QuestionLetterEnum CorrectAnswer { get; set; }  // The correct answer option.

        public int QuizId { get; set; }  // Ties the question to a specific quiz.

        // Optional: Pre-populate options based on enum.
        public List<QuestionOptionDTORequest> QuestionOptions { get; set; } = Enum.GetValues(typeof(QuestionLetterEnum))
            .Cast<QuestionLetterEnum>()
            .Select(letter => new QuestionOptionDTORequest { QuestionOptionLetter = letter })
            .ToList();
    }

}
