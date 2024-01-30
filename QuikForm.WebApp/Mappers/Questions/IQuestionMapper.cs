using QuikForm.Entities;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Mappers.Questions;
public interface IQuestionMapper
{
    Question ToQuestion(QuestionViewModel questionViewModel);
    QuestionViewModel ToQuestionViewModel(Question question);
}