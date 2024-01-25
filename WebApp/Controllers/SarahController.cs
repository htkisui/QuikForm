using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class SarahController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
