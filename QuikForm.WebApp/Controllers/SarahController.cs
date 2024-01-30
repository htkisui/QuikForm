using Microsoft.AspNetCore.Mvc;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.WebApp.Models.Fields;
using QuikForm.WebApp.Models.Questions;

namespace QuikForm.WebApp.Controllers;
public class SarahController : Controller
{
    private readonly IQuestionRepository _questionRepository;

    public SarahController(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<IActionResult> Index()
    {
        var questions = await _questionRepository.GetAllAsync();
        List<QuestionViewModel> questionViewModels = questions.Select(q => new QuestionViewModel { Id = q.Id, IsMandatory = q.IsMandatory, Label = q.Label, FieldViewModels = new List<FieldViewModel> { new FieldViewModel { Id = 1 }, new FieldViewModel { Id = 2 }, new FieldViewModel { Id = 3 } }}).ToList();
        return View(questionViewModels);
    }
}
