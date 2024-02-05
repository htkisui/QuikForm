using QuikForm.Business.Contracts.Responses.InputTypes;
using QuikForm.Entities;

namespace QuikForm.Business.Contracts.Mappers.InputTypes;
public interface IInputTypeMapper
{
    InputType ToInputType(InputTypeResponse inputType);
    InputTypeResponse ToInputTypeResponse(InputType inputType);
}