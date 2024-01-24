using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Input
{
    public int Id { get; set; }
    public string Type { get; set; }

    public List<Question> Questions { get; set; } = [];
}
