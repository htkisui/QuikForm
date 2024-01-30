using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.WebApp.Mappers.InputTypes;
using QuikForm.WebApp.Models.InputTypes;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Views.Shared.Components.QuestionForm;

public class QuestionFormViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(QuestionViewModel questionViewModel)
    {
        var inputTypes = new List<string>()
        {
            "radio", "checkbox", "select", "text", "textarea"
        };
        ViewBag.InputTypes = inputTypes;
        return View(questionViewModel);
    }

    //private readonly IInputTypeBusiness _inputTypeBusiness;
    //private readonly IInputTypeMapper _inputTypeMapper;

    //public QuestionFormViewComponent(IInputTypeBusiness inputTypeBusiness, IInputTypeMapper inputTypeMapper)
    //{
    //    _inputTypeBusiness = inputTypeBusiness;
    //    _inputTypeMapper = inputTypeMapper;
    //}

    //public async Task<IViewComponentResult> InvokeAsync(QuestionViewModel questionViewModel)
    //{
    //    List<InputType> inputTypes = await _inputTypeBusiness.GetAllAsync();
    //    List<InputTypeViewModel> inputTypeViewModels = inputTypes.Select(i => _inputTypeMapper.ToInputTypeViewModel(i)).ToList();
    //    ViewBag.InputTypes = inputTypeViewModels;
    //    return View(questionViewModel);
    //}
}