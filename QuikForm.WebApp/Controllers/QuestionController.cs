using Microsoft.AspNetCore.Mvc;
using QuikForm.Business.Contracts.Business;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Controllers;
public class QuestionController : Controller
{
    private readonly IQuestionBusiness _questionBusiness;

    public QuestionController(IQuestionBusiness questionBusiness)
    {
        _questionBusiness = questionBusiness;
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        try
        {
            int id = await _questionBusiness.CreateAsync();
            QuestionViewModel questionViewModel = new QuestionViewModel() { Id = id };
            return ViewComponent("QuestionForm", new { QuestionViewModel = questionViewModel });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
