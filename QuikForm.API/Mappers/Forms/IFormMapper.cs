using QuikForm.API.Requests.Forms;
using QuikForm.Business.Contracts.Responses.Forms;

namespace QuikForm.API.Mappers.Forms;

public interface IFormMapper
{
    FormResponse ToFormResponse(FormAddRequest formAddRequest);
    FormResponse ToFormResponse(FormUpdateRequest formUpdateRequest);

}
