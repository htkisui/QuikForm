using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Business;
public interface IFormBusiness
{
    /// <summary>
    /// Create a new form.
    /// </summary>
    /// <returns>Id of new form.</returns>
    Task<int> CreateAsync();

    /// <summary>
    /// Get all forms.
    /// </summary>
    /// <returns>List of forms.</returns>
    Task<List<Form>> GetAllAsync();

    /// <summary>
    /// Get a form by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The form.</returns>
    Task<Form> GetByIdAsync(int id);
}
