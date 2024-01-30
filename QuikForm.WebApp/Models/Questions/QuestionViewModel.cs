using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Models.Questions;

public class QuestionViewModel
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public bool? IsMandatory { get; set; }

    public List<FieldViewModel> FieldViewModels { get; set; } = [];

    public InputTypeViewModel InputTypeViewModel { get; set; } = null!;
}