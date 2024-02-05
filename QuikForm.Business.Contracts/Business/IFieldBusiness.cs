using QuikForm.Business.Contracts.Responses.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Business;
public interface IFieldBusiness
{
    Task<FieldResponse> CreateAsync(int questionId);
    Task DeleteAsync(int id);
    Task<FieldResponse> GetByIdAsync(int id);
    Task<FieldResponse> UpdateAsync(int id, string label);
    //Task<FieldResponse> GetResultAsync(int questionId);
}
