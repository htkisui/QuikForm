using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.FieldFormList;

public class FieldFormListViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<FieldViewModel> fieldViewModels, int questionId)
    {
        ViewBag.QuestionId = questionId;
        return View(fieldViewModels);
    }
}
