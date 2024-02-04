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
    /// Clone a new form from an existing one.
    /// </summary>
    /// <param name="id"></param>
    Task CloneAsync(int id);

    /// <summary>
    /// Create a new form.
    /// </summary>
    /// <returns>New form.</returns>
    Task<Form> CreateAsync();

    /// <summary>
    /// Delete form and its children and its children's children (questions and fields).
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
    /// Get all forms closed sorted by descending closed date.
    /// </summary>
    /// <returns>List of formsclosed sorted by descending closed date.</returns>
    Task<List<Form>> GetAllClosedByClosedAtDescAsync();

    /// <summary>
    /// Get all forms published but not closed sorted by descending publication date.
    /// </summary>
    /// <returns>List of forms published but not closed sorted by descending publication date.</returns>
    Task<List<Form>> GetAllPublishedAndNotClosedByPublishedAtDescAsync();

    /// <summary>
    /// Get a form by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The form.</returns>
    Task<Form> GetByIdAsync(int id);

    /// <summary>
    /// Sets Form ClosedAt property to DateTime.Now.
    /// </summary>
    /// <param name="id">Form Id</param>
    /// <returns></returns>
    Task UpdateClosedAt(int id);

    /// <summary>
    /// Update Description of Form.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    Task UpdateDescriptionAsync(int id, string description);

    /// <summary>
    /// Sets PublishedAt Form property to Date.Now.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task UpdatePublishedAt(int id);

    /// <summary>
    /// Update Title of Form.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    Task UpdateTitleAsync(int id, string title);


}
