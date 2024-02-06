using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Mappers.Fields;
using QuikForm.Business.Contracts.Responses.Fields;
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

    private readonly IFieldMapper _fieldMapper;

    public FieldBusiness(IFieldRepository fieldRepository, IFieldMapper fieldMapper)
    {
        _fieldRepository = fieldRepository;
        _fieldMapper = fieldMapper;
    }

    public async Task<FieldResponse> CreateAsync(int questionResponseId)
    {
        Field field = new Field { QuestionId = questionResponseId};
        await _fieldRepository.CreateAsync(field);
        FieldResponse fieldResponse = _fieldMapper.ToFieldResponse(field);
        return fieldResponse;
    }

    public async Task DeleteAsync(int id)
    {
        await _fieldRepository.DeleteAsync(id);
    }

    public async Task<FieldResponse> GetByIdAsync(int id)
    {
        Field field = await _fieldRepository.GetByIdAsync(id);
        FieldResponse fieldResponse = _fieldMapper.ToFieldResponse(field);
        return fieldResponse;
    }

    public async Task<FieldResponse> UpdateAsync(int id, string label)
    {
        Field field = new Field() { Id = id, Label = label };
        await _fieldRepository.UpdateAsync(field);
        FieldResponse fieldResponse = _fieldMapper.ToFieldResponse(field);
        return fieldResponse;
    }
}
