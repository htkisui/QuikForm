using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Record
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CreateAt { get; set; }

    [Required]
    public DateTime UpdateAt { get; set; }

    public List<FieldRecord> FieldRecords { get; } = [];

    public int? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
}
