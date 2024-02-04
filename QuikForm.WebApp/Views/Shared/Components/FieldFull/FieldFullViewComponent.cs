using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.FieldFull;

public class FieldFullViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FieldViewModel fieldViewModel, QuestionViewModel questionViewModel)
    {
        ViewBag.QuestionViewModel = questionViewModel;
        return View(fieldViewModel);
    }
}
