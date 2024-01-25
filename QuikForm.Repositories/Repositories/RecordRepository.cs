using Microsoft.EntityFrameworkCore;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories;
internal class RecordRepository : IRecordRepository
{
    private readonly ApplicationDbContext _context;

    public RecordRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Record record)
    {
        await _context.Records.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Record recordToUpdate = await _context.Records.FirstOrDefaultAsync(r => r.Id == id) ?? throw new RecordNotFoundException();
        _context.Records.Remove(recordToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Record>> GetAllAsync()
    {
        return await _context.Records.ToListAsync();
    }

    public async Task<Record> GetByIdAsync(int id)
    {
        Record record = await _context.Records.FirstOrDefaultAsync(r => r.Id == id) ?? throw new RecordNotFoundException();
        return record;
    }
}
