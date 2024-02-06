using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly IFormBusiness _formBusiness;
    private readonly IFormMapper _formMapper;

    public AdminController(IFormBusiness formBusiness, IFormMapper formMapper)
    {
        _formBusiness = formBusiness;
        _formMapper = formMapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<FormResponse> formResponses = await _formBusiness.GetAllAsync();
        List<FormViewModel> formViewModels = formResponses.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        return View(formViewModels);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Search(string title)
    {
        List<FormResponse> formResponses = await _formBusiness.GetAllByTitleAsync(title);
        List<FormViewModel> formViewmodels = formResponses.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        return View("Index", formViewmodels);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchJS(string title)
    {
        List<FormResponse> formResponses = await _formBusiness.GetAllByTitleAsync(title);
        List<FormViewModel> formViewmodels = formResponses.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        return ViewComponent("FormTable", formViewmodels);
    }
}
