using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Controllers;
public class FormController : Controller
{
    private readonly IFormBusiness _formBusiness;
    private readonly IFormMapper _formMapper;

    public FormController(IFormBusiness formBusiness, IFormMapper formMapper)
    {
        _formBusiness = formBusiness;
        _formMapper = formMapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        Form form = await _formBusiness.CreateAsync();
        return RedirectToAction("Edit", form.Id);
    }

    public async Task<IActionResult> Edit(int id)
    {
        Form form = await _formBusiness.GetByIdAsync(id);
        FormViewModel formViewmodel = _formMapper.ToFormViewModel(form);
        return View(formViewmodel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTitle(int id, string title)
    {
        try
        {
            await _formBusiness.UpdateTitleAsync(id, title);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDescription(int id, string description)
    {
        try
        {
            await _formBusiness.UpdateDescriptionAsync(id, description);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(FormViewModel formViewModel)
    {
        try
        {
            await _formBusiness.DeleteAsync(formViewModel.Id);
            TempData["deletedMessage"] = "Formulaire supprimé";
            return RedirectToAction("Index", "Admin");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Close(FormViewModel formViewModel)
    {
        try
        {
            await _formBusiness.UpdateClosedAt(formViewModel.Id);
            return RedirectToAction("Index", "Admin");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Publish(FormViewModel formViewModel)
    {
        try
        {
            await _formBusiness.UpdatePublishedAt(formViewModel.Id);
            return RedirectToAction("Index", "Admin");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
