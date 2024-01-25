using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repository.Contracts.Contracts;
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

    public Task CreateAsync(Field field)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Field>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Field> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Field> UpdateAsync(Field field)
    {
        throw new NotImplementedException();
    }
}
