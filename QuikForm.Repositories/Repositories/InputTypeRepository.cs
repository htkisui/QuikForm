using Microsoft.EntityFrameworkCore;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.InputTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories;
public class InputTypeRepository : IInputTypeRepository
{
    private ApplicationDbContext _context;

    public InputTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(InputType inputType)
    {
        await _context.InputTypes.AddAsync(inputType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        InputType inputType = await _context.InputTypes.FirstOrDefaultAsync(f => f.Id == id) ?? throw new InputTypeNotFoundException();
        _context.InputTypes.Remove(inputType);
        await _context.SaveChangesAsync();
    }

    public async Task<List<InputType>> GetAllAsync()
    {
        return await _context.InputTypes.ToListAsync();
    }

    public async Task<InputType> GetByIdAsync(int id)
    {
        InputType inputType = await _context.InputTypes.FirstOrDefaultAsync(i => i.Id == id) ?? throw new InputTypeNotFoundException();
        return inputType;
    }

    public async Task<InputType> UpdateAsync(InputType inputType)
    {
        InputType inputTypeToUpdate = await _context.InputTypes.FirstOrDefaultAsync(i => i.Id == inputType.Id) ?? throw new InputTypeNotFoundException();
        inputTypeToUpdate.Name = inputType.Name;

        await _context.SaveChangesAsync();
        return inputTypeToUpdate;

    }
}
