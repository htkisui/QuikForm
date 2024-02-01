using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class QuestionBusiness : IQuestionBusiness
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionBusiness(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<int> CreateAsync()
    {
        Question question = new Question { IsMandatory = true };
        await _questionRepository.CreateAsync(question);
        return question.Id;

    }

    public async Task<Question> GetByIdAsync(int id)
    {
        return await _questionRepository.GetByIdAsync(id);
    }
}
