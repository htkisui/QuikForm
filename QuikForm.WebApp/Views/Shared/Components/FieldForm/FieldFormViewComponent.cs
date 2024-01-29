using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldForm;

public class FieldFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(FieldViewModel fieldViewModel, InputTypeViewModel inputTypeViewModel = null)
    {
        ViewBag.InputType = inputTypeViewModel?.Name;
        ViewBag.MockInputType = "radio"; //temp
        return View(fieldViewModel);
    }
    //public async Task<IViewComponentResult> InvokeAsync()
    //{
    //    return View();
    //}
}
