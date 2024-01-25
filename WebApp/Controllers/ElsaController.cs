using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class ElsaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
