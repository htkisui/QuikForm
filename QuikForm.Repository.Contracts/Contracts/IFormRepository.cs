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
    Task<List<Form>> GetAllByClosedAtDescAsync();

    /// <summary>
    /// Get all forms sorted by descending publication date.
    /// </summary>
    /// <returns>List of formssorted by descending publication date. </returns>
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
