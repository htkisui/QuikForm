using QuikForm.Business.Contracts.Responses.Questions;
using QuikForm.Entities;

namespace QuikForm.Business.Contracts.Mappers.Questions;
public interface IQuestionMapper
{
    Question ToQuestion(QuestionResponse questionResponse);
    QuestionResponse ToQuestionResponse(Question question);
}