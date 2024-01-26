using Microsoft.AspNetCore.Mvc;

namespace QuikForm.WebApp.Controllers;
public class ElsaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
