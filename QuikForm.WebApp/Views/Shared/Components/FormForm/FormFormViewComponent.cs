﻿using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.FormForm;

public class FormFormViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FormViewModel formViewModel)
    {
        return View(formViewModel);
    }
}
