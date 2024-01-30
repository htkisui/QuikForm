using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using System.ComponentModel;
using System.Threading;
using System;

namespace QuikForm.WebApp.Views.Shared.Components.FormTable;

public class FormTableViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<FormViewModel> forms)
    {
        return View(forms);
    }
}