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
    private readonly IFormMapper _formMapper;


    public HomeController(ILogger<HomeController> logger, IFormBusiness formBusiness = null, IFormMapper formMapper = null)
    {
        _logger = logger;
        _formBusiness = formBusiness;
        _formMapper = formMapper;
    }

    //ICI
    public async Task<IActionResult> Index()
    {
        List<Form> forms = await _formBusiness.GetAllByPublishedAtDescAsync();
        List<FormViewModel> formsViewModel = forms.Select(form => _formMapper.ToFormViewModel(form)).ToList();
        return View(formsViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
