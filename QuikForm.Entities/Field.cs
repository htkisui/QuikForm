﻿using System;
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

    //[Required]
    [MaxLength(255)]
    public string? Label { get; set; } = null!;

    //[Required]
    public int QuestionId { get; set; }

    public Question Question { get; set; } = null!;

    public List<FieldRecord> FieldRecords { get; } = [];
}
