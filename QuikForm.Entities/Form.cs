using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class Form
{
    [Key]
    public int Id { get; set; }

    [MaxLength(255)]
    [Required]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;


    public List<Question> Questions { get; set; } = [];
}
