using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Questions;
using QuikForm.WebApp.Models.Forms;
using Riok.Mapperly.Abstractions;

namespace QuikForm.WebApp.Mappers.Forms;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FormMapper : IFormMapper
{
    public partial Form ToForm(FormViewModel formViewModel);

    private partial FormViewModel ToFormViewModelPartial(Form form);
    public FormViewModel ToFormViewModel(Form form)
    {
        var questionMapper = new QuestionMapper();
        var dto = ToFormViewModelPartial(form);
        if (form.Questions != null)
        {
            dto.QuestionViewModels = form.Questions.Select(f => questionMapper.ToQuestionViewModel(f)).ToList();
        }

        return dto;
    }
}
