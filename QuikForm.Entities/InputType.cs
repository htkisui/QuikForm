using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class InputType
{
    [Key]
    public int Id { get; set; }

    //[Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    public List<Question> Questions { get; set; } = [];
}
