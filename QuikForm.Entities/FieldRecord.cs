using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuikForm.Entities;

[PrimaryKey(nameof(FieldId), nameof(RecordId))]
public class FieldRecord
{
    public string? CustomAnswer { get; set; }

    public int FieldId { get; set; }
    public Field Field { get; set; } = null!;

    public int RecordId { get; set; }
    public Record Record { get; set; } = null!;
}
