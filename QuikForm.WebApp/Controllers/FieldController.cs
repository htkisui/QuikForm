using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.Business.Contracts.Responses.Questions;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Fields;
using QuikForm.WebApp.Mappers.Questions;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Controllers;

[Authorize]
public class FieldController : Controller
{
    private readonly IFieldBusiness _fieldBusiness;
    private readonly IQuestionBusiness _questionBusiness;
    private readonly IFieldMapper _fieldMapper;
    private readonly IQuestionMapper _questionMapper;

    public FieldController(IFieldBusiness fieldBusiness, IQuestionBusiness questionBusiness, IFieldMapper fieldMapper, IQuestionMapper questionMapper)
    {
        _fieldBusiness = fieldBusiness;
        _questionBusiness = questionBusiness;
        _fieldMapper = fieldMapper;
        _questionMapper = questionMapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(int questionId)
    {
        try
        {
            FieldResponse fieldResponse = await _fieldBusiness.CreateAsync(questionId);
            FieldViewModel fieldViewModel = _fieldMapper.ToFieldViewModel(fieldResponse);

            QuestionResponse questionResponse = await _questionBusiness.GetByIdAsync(questionId);
            QuestionViewModel questionViewModel = _questionMapper.ToQuestionViewModel(questionResponse);

            return ViewComponent("FieldForm", new { fieldViewModel = fieldViewModel, inputTypeViewModel = questionViewModel.InputTypeViewModel });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _fieldBusiness.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult GetAddButton(int questionId)
    {
        return ViewComponent("FieldAddButton", new { questionId = questionId });
    }


    [HttpPost]
    public async Task<IActionResult> Update(int id, string label)
    {
        try
        {
            await _fieldBusiness.UpdateAsync(id, label);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
