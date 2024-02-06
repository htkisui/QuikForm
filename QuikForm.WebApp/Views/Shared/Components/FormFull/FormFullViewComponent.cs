using Microsoft.AspNetCore.Mvc;
using QuikForm.WebApp.Models.Forms;
using System.ComponentModel;

namespace QuikForm.WebApp.Views.Shared.Components.FormFull;

public class FormFullViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(FormViewModel formViewModel)
    {
        //ViewBag.Url = Url.ToString();
        return View(formViewModel);
    }
}
