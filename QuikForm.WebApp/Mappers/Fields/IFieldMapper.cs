using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.WebApp.Models.Fields;

namespace QuikForm.WebApp.Mappers.Fields;
public interface IFieldMapper
{
    FieldResponse ToFieldResponse(FieldViewModel fieldViewModel);
    FieldViewModel ToFieldViewModel(FieldResponse fieldResponse);
}