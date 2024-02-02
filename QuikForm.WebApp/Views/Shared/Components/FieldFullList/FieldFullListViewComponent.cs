using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Views.Shared.Components.FieldList;

public class FieldFullListViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(List<FieldViewModel> fieldViewModels)
    {
        return View(fieldViewModels);
    }
}
