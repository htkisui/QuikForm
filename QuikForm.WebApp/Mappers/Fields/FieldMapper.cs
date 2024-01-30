using QuikForm.Entities;
using QuikForm.WebApp.Models.Fields;
using Riok.Mapperly.Abstractions;

namespace QuikForm.WebApp.Mappers.Fields;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FieldMapper : IFieldMapper
{
    public partial Field ToField(FieldViewModel fieldViewModel);
    public partial FieldViewModel ToFieldViewModel(Field field);
}
