using QuikForm.Business.Contracts.Responses.Questions;
using System.ComponentModel.DataAnnotations;

namespace QuikForm.API.Requests.Forms;

public class FormUpdateRequest
{
    [Required]
    public int Id { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
}
