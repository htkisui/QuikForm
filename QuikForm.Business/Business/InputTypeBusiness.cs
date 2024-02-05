using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Mappers.InputTypes;
using QuikForm.Business.Contracts.Responses.InputTypes;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class InputTypeBusiness : IInputTypeBusiness
{
    private readonly IInputTypeRepository _inputTypeRepository;
    private readonly IInputTypeMapper _inputTypeMapper;

    public InputTypeBusiness(IInputTypeRepository inputTypeRepository, IInputTypeMapper inputTypeMapper)
    {
        _inputTypeRepository = inputTypeRepository;
        _inputTypeMapper = inputTypeMapper;
    }

    public async Task<List<InputTypeResponse>> GetAllAsync()
    {
        List<InputType> inputTypes = await _inputTypeRepository.GetAllAsync();
        List<InputTypeResponse> inputTypeResponses = inputTypes.Select(i => _inputTypeMapper.ToInputTypeResponse(i)).ToList();
        return inputTypeResponses;
    }
}
