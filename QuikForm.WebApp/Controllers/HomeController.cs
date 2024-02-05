using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Forms;
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

        List<FormResponse> formResponsePublishedAts = await _formBusiness.GetAllPublishedAndNotClosedByPublishedAtDescAsync();
        List<FormViewModel> formsPublishedAtViewModel = formResponsePublishedAts.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        formListsViewModel.FormsPublishedAtViewModel = formsPublishedAtViewModel;

        List<FormResponse> formsClosedAt = await _formBusiness.GetAllClosedByClosedAtDescAsync();
        List<FormViewModel> formsClosedAtViewModel = formsClosedAt.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        formListsViewModel.FormsClosedAtViewModel = formsClosedAtViewModel;

        return View(formListsViewModel);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
