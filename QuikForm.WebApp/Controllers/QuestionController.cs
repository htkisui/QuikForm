using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Questions;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Controllers;
public class QuestionController : Controller
{
    private readonly IQuestionBusiness _questionBusiness;
    private readonly IQuestionMapper _questionMapper;

    public QuestionController(IQuestionBusiness questionBusiness, IQuestionMapper questionMapper)
    {
        _questionBusiness = questionBusiness;
        _questionMapper = questionMapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(int formId)
    {
        try
        {
            Question question = await _questionBusiness.CreateAsync(formId);
            QuestionViewModel questionViewModel = _questionMapper.ToQuestionViewModel(question);

            return ViewComponent("QuestionForm", new { questionViewModel = questionViewModel });
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
            await _questionBusiness.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //[HttpPost]
    //public async Task<IActionResult> Update(int id, string label, bool isMandatory)
    //{
    //    try
    //    {
    //        Question question = await _questionBusiness.Questions.FirstOrDefaultAsync(q => q.Id == id);
    //        if (question != null)
    //        {
    //            question.Label = label;
    //            question.IsMandatory = isMandatory;
    //            await _questionBusiness.UpdateAsync(question);

    //            QuestionViewModel questionViewModel = _questionMapper.ToQuestionViewModel(question);
    //            return Ok(questionViewModel);
    //        }
    //        return NotFound();
    //    }
    //    catch (Exception e)
    //    {
    //        return BadRequest(e.Message);
    //    }
    //}

    [HttpPost]
    public async Task<IActionResult> UpdateLabel(int id, string label)
    {
        try
        {
            await _questionBusiness.UpdateLabelAsync(id, label);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateIsMandatory(int id, bool isMandatory)
    {
        try
        {
            await _questionBusiness.UpdateIsMandatoryAsync(id, isMandatory);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
