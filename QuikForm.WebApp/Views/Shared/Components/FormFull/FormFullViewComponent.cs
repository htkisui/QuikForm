﻿using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using System.ComponentModel;

namespace QuikForm.WebApp.Views.Shared.Components.FormFull;

public class FormFullViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(FormViewModel formViewModel, string role)
    {
        ViewBag.Role = role;
        return View(formViewModel);
    }
}
