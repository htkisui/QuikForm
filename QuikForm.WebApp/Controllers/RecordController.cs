using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Controllers;
public class RecordController : Controller
{
    private readonly IFormBusiness _formBusiness;
    private readonly IRecordBusiness _recordBusiness;
    private readonly IFormMapper _formMapper;

    public RecordController(IFormBusiness formBusiness, IRecordBusiness recordBusiness, IFormMapper formMapper)
    {
        _formBusiness = formBusiness;
        _recordBusiness = recordBusiness;
        _formMapper = formMapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        FormResponse formResponse = await _formBusiness.GetByIdAsync(id);
        FormViewModel formViewModel = _formMapper.ToFormViewModel(formResponse);
        return View(formViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(Dictionary<string, string> records)
    {
        await _recordBusiness.CreateAsync(records);
        return RedirectToAction("Index", "Home");
    }

}
