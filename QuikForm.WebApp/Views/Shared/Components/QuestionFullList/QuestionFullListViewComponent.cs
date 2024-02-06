using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionFullList;

public class QuestionFullListViewComponent : ViewComponent
{

    public IViewComponentResult Invoke(List<QuestionViewModel> questionViewModels)
    {
        return View(questionViewModels);
    }
}
