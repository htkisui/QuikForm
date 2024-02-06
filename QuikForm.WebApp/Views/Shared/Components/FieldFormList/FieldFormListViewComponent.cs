using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.FieldFormList;

public class FieldFormListViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<FieldViewModel> fieldViewModels, int questionId, InputTypeViewModel inputTypeViewModel)
    {
        ViewBag.QuestionId = questionId;
        ViewBag.InputTypeViewModel = inputTypeViewModel;
        return View(fieldViewModels);
    }
}
