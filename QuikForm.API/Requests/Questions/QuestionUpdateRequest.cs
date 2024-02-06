using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.Business.Contracts.Responses.InputTypes;

namespace QuikForm.API.Requests.Questions;

public class QuestionUpdateRequest
{
    public int Id { get; set; }
    public string? Label { get; set; }

    public bool? IsMandatory { get; set; }
}
