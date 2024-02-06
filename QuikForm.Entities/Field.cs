using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Field
{
    [Key]
    public int Id { get; set; }

    [MaxLength(255)]
    public string? Label { get; set; } = null!;

    public int QuestionId { get; set; }

    public Question Question { get; set; } = null!;

    public List<FieldRecord> FieldRecords { get; } = [];
}
