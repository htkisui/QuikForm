using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Controllers;

public class AdminController : Controller
{
    private readonly IFormBusiness _formBusiness;
    private readonly IFormMapper _formMapper;

    public AdminController(IFormBusiness formBusiness, IFormMapper formMapper)
    {
        _formBusiness = formBusiness;
        _formMapper = formMapper;
    }

    public async Task<IActionResult> Index()
    {
        List<Form> forms = await _formBusiness.GetAllAsync();
        List<FormViewModel> formViewModels = forms.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        return View(formViewModels);
    }

    public async Task<IActionResult> Edit(int id)
    {
        Form form = await _formBusiness.GetByIdAsync(id);
        FormViewModel formViewmodel = _formMapper.ToFormViewModel(form);
        return View(formViewmodel);
    }
}
