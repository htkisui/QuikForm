using Microsoft.EntityFrameworkCore;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.FieldRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories;
public class FieldRecordRepository : IFieldRecordRepository
{
    private readonly ApplicationDbContext _context;

    public FieldRecordRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync(int fieldId)
    {
        return await _context.FieldRecords.Where(f => f.FieldId == fieldId).CountAsync();
    }

    public async Task CreateAsync(FieldRecord fieldRecord)
    {
        await _context.FieldRecords.AddAsync(fieldRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int fieldId, int recordId)
    {
        FieldRecord fieldRecord = await _context.FieldRecords.FirstOrDefaultAsync(f => f.FieldId == fieldId && f.RecordId == recordId) ?? throw new FieldRecordNotFoundException();
        _context.FieldRecords.Remove(fieldRecord);
        await _context.SaveChangesAsync();
    }

    public async Task<List<FieldRecord>> GetAllAsync()
    {
        return await _context.FieldRecords.ToListAsync();
    }

    public async Task<FieldRecord> GetByIdAsync(int fieldId, int recordId)
    {
        FieldRecord fieldRecord = await _context.FieldRecords.FirstOrDefaultAsync(f => f.FieldId == fieldId && f.RecordId == recordId) ?? throw new FieldRecordNotFoundException();
        return fieldRecord;
    }

    public async Task<FieldRecord> UpdateAsync(FieldRecord fieldRecord)
    {
        FieldRecord fieldRecordToUpdate = await _context.FieldRecords.FirstOrDefaultAsync(f => f.FieldId == fieldRecord.FieldId && f.RecordId == fieldRecord.RecordId) ?? throw new FieldRecordNotFoundException();

        await _context.SaveChangesAsync();
        return fieldRecordToUpdate;
    }
}
