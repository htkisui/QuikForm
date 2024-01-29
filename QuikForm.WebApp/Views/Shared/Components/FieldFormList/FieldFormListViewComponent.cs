using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;

namespace QuikForm.WebApp.Views.Shared.Components.FieldFormList;

public class FieldFormListViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(List<FieldViewModel> fieldViewModels)
    {
        return View(fieldViewModels);
    }
}
