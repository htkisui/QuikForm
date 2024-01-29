using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionForm;

public class QuestionFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(QuestionViewModel questionViewModel)
    {
        var inputTypes = new List<string>() 
        {
            "radio", "checkbox", "select", "text", "textarea"
        };
        ViewBag.InputTypes = inputTypes;
        return View(questionViewModel);
    }
}
