using Microsoft.AspNetCore.Mvc;

namespace QuikForm.WebApp.Controllers;
public class FormController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
