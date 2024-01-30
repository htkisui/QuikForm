using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionList;

public class QuestionFormListViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<QuestionViewModel> questionViewModels)
    {
        questionViewModels = new List<QuestionViewModel>()
                        {  new QuestionViewModel(){Label ="question1", IsMandatory= true},
                           new QuestionViewModel(){Label ="question2", IsMandatory= false},
                           new QuestionViewModel(){Label ="question2", IsMandatory= true}
                        };
        return View(questionViewModels);
    }
}