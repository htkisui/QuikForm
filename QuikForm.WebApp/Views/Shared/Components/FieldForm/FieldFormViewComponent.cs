using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldForm;

public class FieldFormViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FieldViewModel fieldViewModel, InputTypeViewModel inputTypeViewModel)
    {
        ViewBag.InputTypeViewModel = inputTypeViewModel;
        return View(fieldViewModel);
    }
}
