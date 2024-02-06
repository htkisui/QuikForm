using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuikForm.API.Requests.Fields;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.Business.Contracts.Responses.Questions;

namespace QuikForm.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FieldController : ControllerBase
{
    private readonly IFieldBusiness _fieldBusiness;

    public FieldController(IFieldBusiness fieldBusiness)
    {
        _fieldBusiness = fieldBusiness;
    }

    /// <summary>
    /// Get one field by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The field</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FieldResponse>> GetById(int id)
    {
        try
        {
            var fieldResponse = await _fieldBusiness.GetByIdAsync(id);
            return Ok(fieldResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Create a new field
    /// </summary>
    /// <param name="questionId"></param>
    [HttpPost("{questionId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> Create(int questionId)
    {
        try
        {
            await _fieldBusiness.CreateAsync(questionId);
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
    public async Task<ActionResult> Update(FieldUpdateRequest fieldUptapeRequest)
    {
        try
        {
            if (fieldUptapeRequest.Label != null)
            {
                await _fieldBusiness.UpdateAsync(fieldUptapeRequest.Id, fieldUptapeRequest.Label);
            }
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Delete a field.
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FieldResponse>> Delete(int id)
    {
        try
        {
            await _fieldBusiness.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
