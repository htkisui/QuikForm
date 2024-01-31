using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Fields;
using QuikForm.WebApp.Models.Fields;

namespace QuikForm.WebApp.Controllers;
public class FieldController : Controller
{
    private readonly IFieldBusiness _fieldBusiness;
    private readonly IFieldMapper _fieldMapper;

    public FieldController(IFieldBusiness fieldBusiness, IFieldMapper fieldMapper)
    {
        _fieldBusiness = fieldBusiness;
        _fieldMapper = fieldMapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(int questionId)
    {
        try
        {
            Field field = await _fieldBusiness.CreateAsync(questionId);
            FieldViewModel fieldViewModel = _fieldMapper.ToFieldViewModel(field);

            return ViewComponent("FieldForm", new { fieldViewModel =  fieldViewModel});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
