using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.FieldList;

public class FieldFullListViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(List<FieldViewModel> fieldViewModels, QuestionViewModel questionViewModel)
    {
        ViewBag.QuestionViewModel = questionViewModel;
        return View(fieldViewModels);
    }
}