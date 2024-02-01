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
    /// <returns>New form.</returns>
    Task<Form> CreateAsync();

    /// <summary>
    /// Delete form and its children and its children's children (questions and fields)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(int id);

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

    /// <summary>
    /// Update Title of Form
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <returns></returns>

    Task UpdateTitleAsync(int id,  string title);

    /// <summary>
    /// Update Description of Form
    /// </summary>
    /// <param name="id"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    Task UpdateDescriptionAsync(int id,  string description);
}
