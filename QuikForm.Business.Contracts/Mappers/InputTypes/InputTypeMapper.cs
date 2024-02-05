using QuikForm.Business.Contracts.Responses.InputTypes;
using QuikForm.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Mappers.InputTypes;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class InputTypeMapper : IInputTypeMapper
{
    public partial InputTypeResponse ToInputTypeResponse(InputType inputType);

    public partial InputType ToInputType(InputTypeResponse inputType);
}
