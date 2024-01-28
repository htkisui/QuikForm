using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
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

