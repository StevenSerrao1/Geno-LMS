namespace Geno_API.DTO.DTORequests
{
    public class SelectedAnswerDTORequest
    {
        [Required]
        public QuestionLetterEnum SelectedAnswerLetter { get; set; } // Signifies the char value of the selected answer

        public bool IsCorrect { get; set; } // Bool for checking correctness of answer

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
