using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class FieldBusiness : IFieldBusiness
{
    private readonly IFieldRepository _fieldRepository;

    public FieldBusiness(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<Field> CreateAsync(int questionId)
    {
        Field field = new Field { QuestionId = questionId};
        await _fieldRepository.CreateAsync(field);
        return field;
    }
}
