using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Question
{
    [Key]
    public int Id { get; set; }

    [MaxLength(255)]
    public string? Label { get; set; }

    [Required]
    public bool IsMandatory { get; set; }

    public int FormId { get; set; }

    public Form Form { get; set; } = null!;

    public List<Field> Fields { get; set; } = [];

    public int InputTypeId { get; set; }

    public InputType InputType { get; set; } = null!;
}
