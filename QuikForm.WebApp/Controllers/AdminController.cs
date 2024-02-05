﻿using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Forms;
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
        List<FormResponse> formResponses = await _formBusiness.GetAllAsync();
        List<FormViewModel> formViewModels = formResponses.Select(f => _formMapper.ToFormViewModel(f)).ToList();
        return View(formViewModels);
    }
}
