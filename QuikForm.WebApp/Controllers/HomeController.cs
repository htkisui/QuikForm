using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Models;
using QuikForm.WebApp.Models.Forms;
using System.Diagnostics;

namespace QuikForm.WebApp.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFormBusiness _formBusiness;
    private readonly IRecordBusiness _recordBusiness;
    private readonly IFormMapper _formMapper;

    public HomeController(ILogger<HomeController> logger, IFormBusiness formBusiness, IRecordBusiness recordBusiness, IFormMapper formMapper)
    {
        _logger = logger;
        _formBusiness = formBusiness;
        _recordBusiness = recordBusiness;
        _formMapper = formMapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Submit(int id)
    {
        Form form = await _formBusiness.GetByIdAsync(id);
        FormViewModel formViewModel = _formMapper.ToFormViewModel(form);
        return View(formViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Submit(Dictionary<string, string> records)
    {
        await _recordBusiness.CreateAsync(records);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
