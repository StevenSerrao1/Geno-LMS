namespace Geno_API.DTO.DTOUpdates
{
    public class SelectedAnswerDTOUpdate
    {
        [Required]
        public int SelectedAnswerId { get; set; } // ID to identify which SelectedAnswer to update

        [Required]
        public QuestionLetterEnum SelectedAnswerLetter { get; set; } // The char value of the updated selected answer

        public bool IsCorrect { get; set; } // Boolean to update whether the answer is correct
    }
}
