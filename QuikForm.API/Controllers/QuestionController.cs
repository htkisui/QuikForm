using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikForm.API.Requests.Forms;
using QuikForm.API.Requests.Questions;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.Business.Contracts.Responses.Questions;

namespace QuikForm.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionBusiness _questionBusiness;

    public QuestionController(IQuestionBusiness questionBusiness)
    {
        _questionBusiness = questionBusiness;
    }

    /// <summary>
    /// Get a question by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The question</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<QuestionResponse>> GetById(int id)
    {
        try
        {
            QuestionResponse questionResponse = await _questionBusiness.GetByIdAsync(id);
            return Ok(questionResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Create a new question related to a form.
    /// </summary>
    /// <param name="formId"></param>
    [HttpPost("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]

    public async Task<ActionResult> Create(int formId)
    {
        try
        {
            await _questionBusiness.CreateAsync(formId);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Update(QuestionUpdateRequest questionUpdateRequest)
    {
        try
        {
            if (questionUpdateRequest.Label != null)
            { 
               await _questionBusiness.UpdateLabelAsync(questionUpdateRequest.Id, questionUpdateRequest.Label);
            }
            if (questionUpdateRequest.IsMandatory != null)
            {
                await _questionBusiness.UpdateIsMandatoryAsync(questionUpdateRequest.Id, questionUpdateRequest.IsMandatory);
            }
            return NoContent();
        }
        catch (Exception e) 
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Delete a question.
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<QuestionResponse>> Delete(int id)
    {
        try
        {
            await _questionBusiness.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}