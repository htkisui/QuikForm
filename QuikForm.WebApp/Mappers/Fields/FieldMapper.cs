
using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.WebApp.Models.Fields;
using Riok.Mapperly.Abstractions;

namespace QuikForm.WebApp.Mappers.Fields;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FieldMapper : IFieldMapper
{
    public partial FieldResponse ToFieldResponse(FieldViewModel fieldViewModel);
    public partial FieldViewModel ToFieldViewModel(FieldResponse fieldResponse);
}