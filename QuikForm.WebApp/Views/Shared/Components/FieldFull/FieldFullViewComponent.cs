using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldFull;

public class FieldFullViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FieldViewModel fieldViewModel, InputTypeViewModel? inputTypeViewModel)
    {
        ViewBag.InputType = inputTypeViewModel;
        ViewBag.MockInputType = "checkbox"; //temp (update in cshtml too)
        return View(fieldViewModel);
    }
}
