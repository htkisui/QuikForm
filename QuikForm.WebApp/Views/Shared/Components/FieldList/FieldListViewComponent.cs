using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldList;

public class FieldListViewComponent: ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<FieldViewModel> fieldViewModels)
    {
        return View(fieldViewModels);
    }
}
