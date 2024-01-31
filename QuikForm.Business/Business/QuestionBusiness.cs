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

    public async Task<Question> CreateAsync(int formId)
    {
        Question question = new Question { FormId = formId, InputTypeId = 1 };
        Question questionWithInputType = await _questionRepository.CreateAsync(question);
        return questionWithInputType;
    }
}
