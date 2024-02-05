using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.Business.Contracts.Responses.InputTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Responses.Questions;
public class QuestionResponse
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public bool IsMandatory { get; set; }

    public List<FieldResponse> FieldResponses { get; set; } = [];

    public InputTypeResponse InputTypeResponse { get; set; } = null!;
}
