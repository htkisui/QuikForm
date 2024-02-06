using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Contracts;
public interface IFormRepository
{
    /// <summary>
    /// Create a new form.
    /// </summary>
    /// <param name="form"></param>
    Task CreateAsync(Form form);

    /// <summary>
    /// Delete a form by Id and its questions and fields.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>True if deleted.</returns>
    Task DeleteAsync(int id);

    /// <summary>
    /// Get all forms and their questions and fields..
    /// </summary>
    /// <returns>List of all forms.</returns>
    Task<List<Form>> GetAllAsync();

    /// <summary>
    /// Get all forms by their title.
    /// </summary>
    /// <param name="title"></param>
    /// <returns>List of Forms.</returns>
    Task<List<Form>> GetAllByTitleAsync(string title);

    /// <summary>
    /// Get all forms closed sorted by descending closed date.
    /// </summary>
    /// <returns>List of formsclosed sorted by descending closed date.</returns>
    Task<List<Form>> GetAllClosedByClosedAtDescAsync();

    /// <summary>
    /// Get all forms sorted by descending closed date.
    /// </summary>
    /// <returns>List of formssorted by descending closed date.</returns>
    Task<List<Form>> GetAllByClosedAtDescAsync();

    /// <summary>
    /// Get all forms published but not closed sorted by descending publication date.
    /// </summary>
    /// <returns>List of forms published but not closed sorted by descending publication date.</returns>
    Task<List<Form>> GetAllPublishedAndNotClosedByPublishedAtDescAsync();

    /// <summary>
    /// Get all forms sorted by descending publication date.
    /// </summary>
    /// <returns>List of formssorted by descending publication date.</returns>
    Task<List<Form>> GetAllByPublishedAtDescAsync();

    /// <summary>
    /// Get one form by id and its questions and fields .
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The form.</returns>
    Task<Form> GetByIdAsync(int id);

    /// <summary>
    /// Update a form by id.
    /// </summary>
    /// <param name="form"></param>
    /// <returns>The Updated form.</returns>
    Task<Form> UpdateAsync(Form form);
}
