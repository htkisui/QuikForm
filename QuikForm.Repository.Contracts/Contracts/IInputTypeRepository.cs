using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Contracts;
public interface IInputTypeRepository
{
    /// <summary>
    /// Create a new InputType.
    /// </summary>
    /// <param name="inputType"></param>
    Task CreateAsync(InputType inputType);

    /// <summary>
    /// Delete an InputType by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>True if deleted.</returns>
    Task DeleteAsync(int id);

    /// <summary>
    /// Get all inputTypes.
    /// </summary>
    /// <returns>List of all InputTypes.</returns>
    Task<List<InputType>> GetAllAsync();

    /// <summary>
    /// Get one inputType by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The input.</returns>
    Task<InputType> GetByIdAsync(int id);

    /// <summary>
    /// Update inputType by id.
    /// </summary>
    /// <param name="inputType"></param>
    Task UpdateAsync(InputType inputType);

}
