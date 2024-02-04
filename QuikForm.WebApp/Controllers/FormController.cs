﻿using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Fields;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Controllers;
public class FormController : Controller
{
    private readonly IFormBusiness _formBusiness;
    private readonly IFormMapper _formMapper;
    private readonly IRecordBusiness _recordBusiness;

    public FormController(IFormBusiness formBusiness, IFormMapper formMapper, IRecordBusiness recordBusiness)
    {
        _formBusiness = formBusiness;
        _formMapper = formMapper;
        _recordBusiness = recordBusiness;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Clone(int id)
    {
        await _formBusiness.CloneAsync(id);
        return RedirectToAction("Index", "Admin");
    }

    public async Task<IActionResult> Create()
    {
        Form form = await _formBusiness.CreateAsync();
        return RedirectToAction("Edit", new { id = form.Id });
    }

    public async Task<IActionResult> Edit(int id)
    {
        Form form = await _formBusiness.GetByIdAsync(id);
        FormViewModel formViewmodel = _formMapper.ToFormViewModel(form);
        return View(formViewmodel);
    }

    public async Task<IActionResult> Show(int id)
    {
        Form form = await _formBusiness.GetByIdAsync(id);
        FormViewModel formViewmodel = _formMapper.ToFormViewModel(form);
        return View(formViewmodel);
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
        return RedirectToAction("Index", "Home");
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
