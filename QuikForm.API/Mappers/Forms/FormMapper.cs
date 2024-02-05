using QuikForm.API.Requests.Forms;
using QuikForm.Business.Contracts.Responses.Forms;
using Riok.Mapperly.Abstractions;

namespace QuikForm.API.Mappers.Forms;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FormMapper : IFormMapper
{
    //public FormResponse ToFormResponse(FormAddRequest formAddRequest)
    //{
    //    throw new NotImplementedException();
    //}

    //public FormResponse ToFormResponse(FormUpdateRequest formUpdateRequest)
    //{
    //    throw new NotImplementedException();
    //}
}