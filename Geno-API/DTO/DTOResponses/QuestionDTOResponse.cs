namespace Geno_API.DTO.DTOResponses
{
    public class QuestionDTOResponse
    {
        public int QuestionId { get; set; } // Unique Identifier of the Question

        public string? QuestionText { get; set; } // The actual question content

        public QuestionLetterEnum CorrectAnswer { get; set; } // The correct answer letter (A, B, C, D)

        public int QuizId { get; set; } // The ID of the quiz to which the question belongs

        public QuizDTOResponse? Quiz { get; set; } // Detailed quiz information

        public List<QuestionOptionDTOResponse> QuestionOptions { get; set; } // List of options (with answer text)

        public List<SelectedAnswerDTOResponse> SelectedAnswers { get; set; } // List of selected answers by students

        public QuestionDTOResponse() // Constructor to initialize the properties
        {
            QuestionOptions = new List<QuestionOptionDTOResponse>();
            SelectedAnswers = new List<SelectedAnswerDTOResponse>(); // Include selected answers if needed
        }

    }
}
