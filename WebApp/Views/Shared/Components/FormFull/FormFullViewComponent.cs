using Microsoft.AspNetCore.Mvc;

namespace WebApp.Views.Shared.Components.FormFull;

public class FormFullViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
