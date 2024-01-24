using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Answer
{
    public string? CustomAnswer { get; set; }

    public int CompletedFormId { get; set; }
    public CompletedForm CompletedForm { get; set; }

    public int FieldId { get; set; }
    public Field Field { get; set; }
}
