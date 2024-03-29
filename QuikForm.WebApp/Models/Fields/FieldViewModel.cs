﻿using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Models.Fields;

public class FieldViewModel
{
    public int Id { get; set; }
    public string Label { get; set; } = null!;

    public QuestionViewModel QuestionViewModel { get; set; }

    public int Count { get; set; } = -1;

    public float Percent { get; set; }
}
