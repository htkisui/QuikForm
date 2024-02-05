using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Responses.InputTypes;
using QuikForm.Entities;
using QuikForm.WebApp.Mappers.InputTypes;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Services;

public class InputTypeService
{
    private readonly IInputTypeBusiness _inputTypeBusiness;
    private readonly IInputTypeMapper _inputTypeMapper;

    public InputTypeService(IInputTypeBusiness inputTypeBusiness, IInputTypeMapper inputTypeMapper)
    {
        _inputTypeBusiness = inputTypeBusiness;
        _inputTypeMapper = inputTypeMapper;
    }

    public async Task<List<InputTypeViewModel>> GetAllAsync()
    {
        List<InputTypeResponse> inputTypeResponses = await _inputTypeBusiness.GetAllAsync();
        List<InputTypeViewModel> inputTypeViewModels = inputTypeResponses.Select(i => _inputTypeMapper.ToInputTypeViewModel(i)).ToList();
        return inputTypeViewModels;
    }
}
