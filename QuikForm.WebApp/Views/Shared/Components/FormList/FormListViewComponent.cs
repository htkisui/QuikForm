using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using QuikForm.WebApp.Models.Questions;
using System.ComponentModel;

namespace QuikForm.WebApp.Views.Shared.Components.FormList;

public class FormListViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<FormViewModel> formViewModels)
    {
        return View(formViewModels);
    }
}