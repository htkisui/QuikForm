using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuikForm.API.Mappers.Forms;
using QuikForm.API.Requests.Forms;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Forms;

namespace QuikForm.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormController : ControllerBase
{
    private readonly IFormBusiness _formBusiness;

    public FormController(IFormBusiness formBusiness)
    {
        _formBusiness = formBusiness;
    }

    /// <summary>
    /// Get all forms.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<FormResponse>> GetAll()
    {
        var formResponses = await _formBusiness.GetAllAsync();
        return Ok(formResponses);
    }

    /// <summary>
    /// Get one form by his id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FormResponse>> GetById(int id)
    {
        try
        {
            var formResponse = await _formBusiness.GetByIdAsync(id);
            return Ok(formResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Create a new form
    /// </summary>
    /// <param name="formAddRequest"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> Create()
    {
        try
        {
            await _formBusiness.CreateAsync();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Update a form.
    /// </summary>
    /// <param name="formUpdateRequest"></param>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Update(FormUpdateRequest formUpdateRequest)
    {
        try
        {
            if (formUpdateRequest.Title != null)
            {
                await _formBusiness.UpdateTitleAsync(formUpdateRequest.Id, formUpdateRequest.Title);
            }

            if (formUpdateRequest.Description != null)
            {
                await _formBusiness.UpdateDescriptionAsync(formUpdateRequest.Id, formUpdateRequest.Description);
            }

            if (formUpdateRequest.PublishedAt != null)
            {
                await _formBusiness.UpdatePublishedAt(formUpdateRequest.Id);
            }

            if (formUpdateRequest.PublishedAt != null)
            {
                await _formBusiness.UpdateClosedAt(formUpdateRequest.Id);
            }

            return NoContent();

        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Delete a form.
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FormResponse>> Delete(int id)
    {
        try
        {
            await _formBusiness.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
