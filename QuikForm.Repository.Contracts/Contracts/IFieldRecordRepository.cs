using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Contracts;
public interface IFieldRecordRepository
{
    /// <summary>
    /// Create a new FieldRecord.
    /// </summary>
    /// <param name="fieldRecord"></param>
    Task CreateAsync(FieldRecord fieldRecord);

    /// <summary>
    /// Delete a FieldRecord by field's id and record's id.
    /// </summary>
    /// <param name="id"></param>
    Task DeleteAsync(int fieldId, int recordId);

    /// <summary>
    /// Get all fieldRecords.
    /// </summary>
    /// <returns>All fieldRecord.</returns>
    Task<List<FieldRecord>> GetAllAsync();

    /// <summary>
    /// Get one fieldRecord by field's id and record's id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The fieldRecord one.</returns>
    Task<FieldRecord> GetByIdAsync(int fieldId, int recordId);

    /// <summary>
    /// Update a fieldRecord.
    /// </summary>
    /// <param name="fieldRecord"></param>
    /// <returns>Field updated.</returns>
    Task<FieldRecord> UpdateAsync(FieldRecord fieldRecord);
}
