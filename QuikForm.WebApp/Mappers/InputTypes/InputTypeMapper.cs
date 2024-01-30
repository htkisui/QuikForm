using QuikForm.Entities;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Mappers.Questions;
using QuikForm.WebApp.Models.Forms;
using QuikForm.WebApp.Models.InputTypes;
using Riok.Mapperly.Abstractions;

namespace QuikForm.WebApp.Mappers.InputTypes;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class InputTypeMapper : IInputTypeMapper
{
    public partial InputType ToInputType(InputTypeViewModel inputTypeViewModel);

    public partial InputTypeViewModel ToInputTypeViewModel(InputType inputType);
}
