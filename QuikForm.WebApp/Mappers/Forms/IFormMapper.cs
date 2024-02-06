using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.Entities;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Mappers.Forms;

public interface IFormMapper
{
    FormResponse ToFormResponse(FormViewModel formViewModel);
    FormViewModel ToFormViewModel(FormResponse formResponse);
}
