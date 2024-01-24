using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class CompletedForm
{
    public int Id { get; set; }

    public List<Answer> Answers { get; set; } = [];

    public int? UserId { get; set; }
    public User? User { get; set; }
}
