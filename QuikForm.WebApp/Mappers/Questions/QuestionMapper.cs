using QuikForm.Business.Contracts.Responses.Questions;
using QuikForm.WebApp.Mappers.Fields;
using QuikForm.WebApp.Mappers.InputTypes;
using QuikForm.WebApp.Models.Questions;
using Riok.Mapperly.Abstractions;

namespace QuikForm.WebApp.Mappers.Questions;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class QuestionMapper : IQuestionMapper
{
    public partial QuestionResponse ToQuestionResponse(QuestionViewModel questionViewModel);

    private partial QuestionViewModel ToQuestionViewModelPartial(QuestionResponse questionResponse);

    public QuestionViewModel ToQuestionViewModel(QuestionResponse questionResponse)
    {
        var fieldMapper = new FieldMapper();
        var inputTypeMapper = new InputTypeMapper();
        var dto = ToQuestionViewModelPartial(questionResponse);
        if (questionResponse.FieldResponses != null)
        {
            dto.FieldViewModels = questionResponse.FieldResponses.Select(q => fieldMapper.ToFieldViewModel(q)).ToList();
        }
        if (questionResponse.InputTypeResponse != null)
        {
            dto.InputTypeViewModel = inputTypeMapper.ToInputTypeViewModel(questionResponse.InputTypeResponse);
        }
        return dto;
    }
}
