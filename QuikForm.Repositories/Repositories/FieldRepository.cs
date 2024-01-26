using Microsoft.EntityFrameworkCore;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories;
public class FieldRepository : IFieldRepository
{
    private readonly ApplicationDbContext _context;

    public FieldRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Field field)
    {
        await _context.Fields.AddAsync(field);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Id == id) ?? throw new FieldNotFoundException();
        _context.Fields.Remove(field);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Field>> GetAllAsync()
    {
        return await _context.Fields.ToListAsync();
    }

    public async Task<Field> GetByIdAsync(int id)
    {
        Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Id == id) ?? throw new FieldNotFoundException();
        return field;
    }

    public async Task<Field> UpdateAsync(Field field)
    {
        Field fieldToUpdate =  await _context.Fields.FirstOrDefaultAsync(f => f.Id == field.Id) ?? throw new FieldNotFoundException();

        fieldToUpdate.Label = field.Label;

        await _context.SaveChangesAsync();
        return fieldToUpdate;
    }
}
