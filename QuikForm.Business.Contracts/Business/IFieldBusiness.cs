using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Business;
public interface IFieldBusiness
{
    Task<Field> CreateAsync(int questionId);
    Task DeleteAsync(int id);
    Task<Field> GetByIdAsync(int id);
    Task<Field> UpdateAsync(int id, string label);
}
