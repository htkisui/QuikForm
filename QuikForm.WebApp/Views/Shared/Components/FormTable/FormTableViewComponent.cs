using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using System.ComponentModel;
using System.Threading;
using System;

namespace QuikForm.WebApp.Views.Shared.Components.FormTable;

public class FormTableViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<FormViewModel> formViewModels)
    {
        return View(formViewModels);
    }
}