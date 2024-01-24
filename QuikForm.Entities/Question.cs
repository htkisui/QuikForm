using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Question
{
    public int Id { get; set; }
    public string Label { get; set; }
    public bool IsMandatory { get; set; }

    public int FormId { get; set; }
    public Form Form { get; set; }

    public List<Field> Fields { get; set; } = [];

    public int InputId { get; set; }
    public Input Input { get; set; }
}
