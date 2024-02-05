using QuikForm.Business.Contracts.Responses.Questions;

namespace QuikForm.API.Mappers.Forms;

public class FormAddRequest
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public List<QuestionResponse> QuestionResponses { get; set; } = [];
}