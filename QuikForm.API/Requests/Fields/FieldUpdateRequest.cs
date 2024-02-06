using QuikForm.Business.Contracts.Responses.Questions;

namespace QuikForm.API.Requests.Fields;

public class FieldUpdateRequest
{
    public int Id { get; set; }
    public string Label { get; set; } = null!;
}
