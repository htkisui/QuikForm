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

    public HomeController(ILogger<HomeController> logger, IFormBusiness formBusiness, IFormMapper formMapper)
    {
        _logger = logger;
        _formBusiness = formBusiness;
        _formMapper = formMapper;
    }

    public async Task<IActionResult> Index()
    {
        FormListsViewModel formListsViewModel = new FormListsViewModel();
        
        List<Form> formsPublishedAt = await _formBusiness.GetAllByPublishedAtDescAsync();
        List<FormViewModel> formsPublishedAtViewModel = formsPublishedAt.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        formListsViewModel.FormsPublishedAtViewModel = formsPublishedAtViewModel;

        List<Form> formsClosedAt = await _formBusiness.GetAllByClosedAtDescAsync();
        List<FormViewModel> formsClosedAtViewModel = formsClosedAt.Select(f => _formMapper.ToFormViewModel(f)).ToList() ;
        formListsViewModel.FormsClosedAtViewModel = formsClosedAtViewModel;

        return View(formListsViewModel);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
