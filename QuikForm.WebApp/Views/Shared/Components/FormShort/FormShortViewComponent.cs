using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Views.Shared.Components.FormShort;

public class FormShortViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(FormViewModel formViewModel)
    {
        return View(formViewModel);
    }
}