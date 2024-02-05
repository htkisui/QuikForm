using QuikForm.Business.Contracts.Responses.Questions;

namespace QuikForm.API.Requests.Forms;

public class FormUpdateRequest
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    //public List<QuestionResponse> QuestionResponses { get; set; } = [];
}
