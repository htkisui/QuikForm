using QuikForm.Business.Contracts.Business;
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
        List<InputType> inputTypes = await _inputTypeBusiness.GetAllAsync();
        List<InputTypeViewModel> inputTypeViewModels = inputTypes.Select(i => _inputTypeMapper.ToInputTypeViewModel(i)).ToList();
        return inputTypeViewModels;
    }
}
