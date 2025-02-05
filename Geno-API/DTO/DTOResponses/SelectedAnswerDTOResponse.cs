namespace Geno_API.DTO.DTOResponses
{
    public class SelectedAnswerDTOResponse
    {
        public int SelectedAnswerId { get; set; } // The ID of the selected answer (to confirm it was saved/returned correctly)

        public QuestionLetterEnum SelectedAnswerLetter { get; set; } // The char value of the selected answer

        public bool IsCorrect { get; set; } // Whether the answer was correct or not

        public int QuestionId { get; set; } // The ID of the question associated with this answer

        public int StudentId { get; set; } // The ID of the student who selected this answer

    }
}
