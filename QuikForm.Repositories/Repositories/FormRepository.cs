﻿using Microsoft.EntityFrameworkCore;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories;
public class FormRepository : IFormRepository
{
    private readonly ApplicationDbContext _context;

    public FormRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Form form)
    {
        await _context.AddRangeAsync(form);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Form formToDelete = await _context.Forms.FirstOrDefaultAsync(i => i.Id == id)?? throw new FormNotFoundException();
        _context.Forms.Remove(formToDelete);
        await _context.SaveChangesAsync();
    }

    public Task<List<Form>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Form> GetByIdAsync(int id)
    {
        Form form = await _context.Forms.FirstOrDefaultAsync(i => i.Id == id) ?? throw new FormNotFoundException();
        return form;
    }

    public Task<Form> UpdateAsync(Form form)
    {
        throw new NotImplementedException();
    }
}
