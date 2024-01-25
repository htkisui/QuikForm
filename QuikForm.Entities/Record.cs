﻿using System;
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

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public List<FieldRecord> FieldRecords { get; } = [];

    public int? UserId { get; set; }
    public User? User { get; set; }
}
