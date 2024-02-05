using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.Entities;

namespace QuikForm.Business.Contracts.Mappers.Forms;
public interface IFormMapper
{
    Form ToForm(FormResponse formResponse);
    FormResponse ToFormResponse(Form form);
}