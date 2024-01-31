using Microsoft.AspNetCore.Mvc;
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
}
