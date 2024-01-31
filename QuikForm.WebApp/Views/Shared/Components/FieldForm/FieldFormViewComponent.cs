using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldForm;

public class FieldFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(FieldViewModel fieldViewModel, InputTypeViewModel inputTypeViewModel)
    {
        ViewBag.InputType = inputTypeViewModel;
        return View(fieldViewModel);
    }
}
