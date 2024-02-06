using QuikForm.Business.Contracts.Responses.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Responses.Fields;
public class FieldResponse
{
    public int Id { get; set; }
    public string Label { get; set; } = null!;

    public QuestionResponse QuestionResponse { get; set; } = null!;

    public int Count { get; set; } = -1;

    public float Percent { get; set; }
}
