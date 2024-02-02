using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionFullList;

public class QuestionFullListViewComponent : ViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync(List<QuestionViewModel> questionViewModels)
    {
        return View(questionViewModels);
    }
}
