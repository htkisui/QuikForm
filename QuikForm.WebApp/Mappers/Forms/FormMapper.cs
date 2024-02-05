using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.WebApp.Mappers.Questions;
using QuikForm.WebApp.Models.Forms;
using Riok.Mapperly.Abstractions;

namespace QuikForm.WebApp.Mappers.Forms;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FormMapper : IFormMapper
{
    public partial FormResponse ToFormResponse(FormViewModel formViewModel);

    private partial FormViewModel ToFormViewModelPartial(FormResponse formResponse);

    public FormViewModel ToFormViewModel(FormResponse formResponse)
    {
        var questionMapper = new QuestionMapper();
        var dto = ToFormViewModelPartial(formResponse);
        if (formResponse.QuestionResponses != null)
        {
            dto.QuestionViewModels = formResponse.QuestionResponses.Select(f => questionMapper.ToQuestionViewModel(f)).ToList();
        }

        return dto;
    }
}
