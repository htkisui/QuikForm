using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.WebApp.Models.Fields;

namespace QuikForm.WebApp.Controllers;
public class FieldController : Controller
{
    private readonly IFieldBusiness _fieldBusiness;

    public FieldController(IFieldBusiness fieldBusiness)
    {
        _fieldBusiness = fieldBusiness;
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        try
        {
            int id = await _fieldBusiness.CreateAsync();
            FieldViewModel fieldViewModel = new FieldViewModel() { Id = id };
            return ViewComponent("FieldForm", new { fieldViewModel =  fieldViewModel});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
