using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Responses.InputTypes;
public class InputTypeResponse
{
    public int Id { get; set; }
    public string Label { get; set; } = null!;
    public string Markup { get; set; } = null!;
}
