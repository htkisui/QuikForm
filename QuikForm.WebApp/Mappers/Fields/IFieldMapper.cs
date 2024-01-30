using QuikForm.Entities;
using QuikForm.WebApp.Models.Fields;

namespace QuikForm.WebApp.Mappers.Fields;
public interface IFieldMapper
{
    Field ToField(FieldViewModel fieldViewModel);
    FieldViewModel ToFieldViewModel(Field field);
}