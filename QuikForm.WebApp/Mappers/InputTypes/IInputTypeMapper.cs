using QuikForm.Business.Contracts.Responses.InputTypes;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Mappers.InputTypes;
public interface IInputTypeMapper
{
    InputTypeResponse ToInputTypeResponse(InputTypeViewModel inputTypeViewModel);
    InputTypeViewModel ToInputTypeViewModel(InputTypeResponse inputType);
}