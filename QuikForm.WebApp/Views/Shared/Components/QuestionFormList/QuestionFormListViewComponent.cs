﻿using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionList;

public class QuestionFormListViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<QuestionViewModel> questionViewModels, int formId)
    {
        ViewBag.FormId = formId;
        return View(questionViewModels);
    }
}