using QuikForm.Business.Contracts.Responses.Questions;
using QuikForm.Entities;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Mappers.Questions;
public interface IQuestionMapper
{
    QuestionResponse ToQuestionResponse(QuestionViewModel questionViewModel);
    QuestionViewModel ToQuestionViewModel(QuestionResponse questionResponse);
}