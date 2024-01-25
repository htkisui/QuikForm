using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Contracts;
public interface IRecordRepository
{
    /// <summary>
    /// Create a new record
    /// </summary>
    /// <param name="record"></param>
    Task CreateAsync(Record record);

    /// <summary>
    /// Delete a record by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>True if deleted.</returns>
    Task DeleteAsync(int id);

    /// <summary>
    /// Get all records.
    /// </summary>
    /// <returns>List of all records.</returns>
    Task<List<Record>> GetAllAsync();

    /// <summary>
    /// Get one record by id. 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The record.</returns>
    Task<Record> GetByIdAsync(int id);

    /// <summary>
    /// Update a record by id.
    /// </summary>
    /// <param name="record"></param>
    /// <returns>The updated record </returns>
    Task<Record> UpdateAsync(Record record);
}
