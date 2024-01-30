using QuikForm.Entities;
using QuikForm.WebApp.Models.Forms;

namespace QuikForm.WebApp.Mappers.Forms;

public interface IFormMapper
{
    Form ToForm(FormViewModel formViewModel);
    FormViewModel ToFormViewModel(Form form);
}
