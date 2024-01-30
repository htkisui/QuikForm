using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;

namespace QuikForm.WebApp.Controllers;

public class AdminController : Controller
{
    private readonly IFormBusiness _formBusiness;

    public AdminController(IFormBusiness formBusiness)
    {
        _formBusiness = formBusiness;
    }

    public async Task<IActionResult> Index()
    {

        return View();
    }
}
