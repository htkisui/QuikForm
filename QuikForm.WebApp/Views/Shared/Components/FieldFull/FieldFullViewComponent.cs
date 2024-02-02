using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldFull;

public class FieldFullViewComponent : ViewComponent
{

    public IViewComponentResult Invoke(FieldViewModel fieldViewModel)
    {
        return View(fieldViewModel);
    }
}
