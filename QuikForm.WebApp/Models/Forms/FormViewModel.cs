﻿using QuikForm.WebApp.Models.Questions;
using System.ComponentModel.DataAnnotations;

namespace QuikForm.WebApp.Models.Forms;

public class FormViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public List<QuestionViewModel> QuestionViewModels { get; set; } = [];
}
