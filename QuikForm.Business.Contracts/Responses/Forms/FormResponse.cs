using QuikForm.Business.Contracts.Responses.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Responses.Forms;
public class FormResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public List<QuestionResponse> QuestionResponses { get; set; } = [];
}
