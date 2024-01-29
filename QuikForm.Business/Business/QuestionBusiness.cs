using QuikForm.Business.Contracts.Business;
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
}
