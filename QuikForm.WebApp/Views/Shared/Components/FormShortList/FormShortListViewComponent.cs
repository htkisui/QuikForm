using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using QuikForm.WebApp.Models.Questions;
using System.ComponentModel;

namespace QuikForm.WebApp.Views.Shared.Components.FormShortList;

public class FormShortListViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<FormViewModel> formViewModels)
    {
        return View(formViewModels);
    }
}