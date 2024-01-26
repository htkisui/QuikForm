using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldFull;

public class FieldFullViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(FieldViewModel fieldViewModel, InputTypeViewModel inputTypeViewModel = null)
    {
        ViewBag.InputType = inputTypeViewModel?.Name;
        ViewBag.MockInputType = "checkbox"; //temp (change in cshtml too)
        return View(fieldViewModel);
    }
}
