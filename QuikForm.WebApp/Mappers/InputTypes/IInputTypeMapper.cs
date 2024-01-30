using QuikForm.Entities;
using QuikForm.WebApp.Models.InputTypes;

namespace QuikForm.WebApp.Mappers.InputTypes;
public interface IInputTypeMapper
{
    InputType ToInputType(InputTypeViewModel inputTypeViewModel);
    InputTypeViewModel ToInputTypeViewModel(InputType inputType);
}