using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Field
{
    public int Id { get; set; }
    public string Label { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
