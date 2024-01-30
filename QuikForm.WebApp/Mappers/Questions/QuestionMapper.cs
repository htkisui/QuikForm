using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Fields;
using QuikForm.WebApp.Models.Questions;
using Riok.Mapperly.Abstractions;

namespace QuikForm.WebApp.Mappers.Questions;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class QuestionMapper : IQuestionMapper
{
    public partial Question ToQuestion(QuestionViewModel questionViewModel);

    private partial QuestionViewModel ToQuestionViewModelPartial(Question question);

    public QuestionViewModel ToQuestionViewModel(Question question)
    {
        var fieldMapper = new FieldMapper();
        var dto = ToQuestionViewModelPartial(question);
        if (question.Fields != null)
        {
            dto.FieldViewModels = question.Fields.Select(q => fieldMapper.ToFieldViewModel(q)).ToList();
        }

        return dto;
    }
}
