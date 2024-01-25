using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Contracts;
public interface IFieldRepository
{
    /// <summary>
    /// Create a new field in a question.
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    Task CreateAsync(Field field);

    /// <summary>
    /// Delete a field of a question.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(int id);

    /// <summary>
    /// Get all fields of a question.
    /// </summary>
    /// <returns>All answer choices in a question.</returns>
    Task<List<Field>> GetAllAsync();

    /// <summary>
    /// Get one field (answer) of a question.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>One field in a question.</returns>
    Task<Field> GetById(int id);

    /// <summary>
    /// Update a question field.
    /// </summary>
    /// <param name="field"></param>
    /// <returns>Field updated.</returns>
    Task<Field> UpdateAsync(Field field);
}
