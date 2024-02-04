using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldAddButton;

public class FieldAddButtonViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(int questionId)
    {
        return View(questionId);
    }
}