using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.InputTypes;
using QuikForm.WebApp.Models.InputTypes;
using QuikForm.WebApp.Models.Questions;
using QuikForm.WebApp.Services;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionForm;

public class QuestionFormViewComponent : ViewComponent
{
    private readonly InputTypeService _inputTypeService;

    public QuestionFormViewComponent(InputTypeService inputTypeService)
    {
        _inputTypeService = inputTypeService;
    }

    public async Task<IViewComponentResult> InvokeAsync(QuestionViewModel questionViewModel)
    {
        List<InputTypeViewModel> inputTypeViewModels = await _inputTypeService.GetAllAsync();
        ViewBag.InputTypes = inputTypeViewModels;
        return View(questionViewModel);
    }
}