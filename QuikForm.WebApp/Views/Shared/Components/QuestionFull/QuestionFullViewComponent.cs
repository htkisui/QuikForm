using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionFull;

public class QuestionFullViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(QuestionViewModel questionViewModel)
    {
        return View(questionViewModel);
    }
}
