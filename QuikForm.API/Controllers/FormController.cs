using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuikForm.API.Mappers.Forms;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.Forms;

namespace QuikForm.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormController : ControllerBase
{
    private readonly IFormBusiness _formBusiness;
    private readonly IFormMapper _formMapper;

    public FormController(IFormBusiness formBusiness, IFormMapper formMapper)
    {
        _formBusiness = formBusiness;
        _formMapper = formMapper;

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
    public async Task<ActionResult> Create(FormAddRequest formAddRequest)
    {
        try
        {
            await _formBusiness.CreateAsync(formAddRequest);
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
            await _formBusiness.UpdateAsync(formUpdateRequest);
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
            FormResponse formResponse = await _formBusiness.DeleteAsync(id);
            return Ok(formResponse);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
