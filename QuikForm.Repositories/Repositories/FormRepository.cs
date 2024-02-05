using Microsoft.EntityFrameworkCore;
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
        form.CreatedAt = DateTime.Now;
        form.UpdatedAt = DateTime.Now;
        await _context.Forms.AddAsync(form);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Form formToDelete = await _context.Forms.FirstOrDefaultAsync(f => f.Id == id) ?? throw new FormNotFoundException();
        _context.Forms.Remove(formToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Form>> GetAllAsync()
    {
        return await _context.Forms.ToListAsync();
    }

    public async Task<List<Form>> GetAllClosedByClosedAtDescAsync()
    {
        return await _context.Forms
            .Where(f => f.ClosedAt != null && f.ClosedAt >= DateTime.Now)
            .OrderByDescending(f => f.ClosedAt)
            .ToListAsync();
    }

    public async Task<List<Form>> GetAllByClosedAtDescAsync()
    {
        return await _context.Forms.OrderByDescending(f => f.ClosedAt).ToListAsync();
    }

    public async Task<List<Form>> GetAllPublishedAndNotClosedByPublishedAtDescAsync()
    {
        return await _context.Forms
            .Where(f => f.PublishedAt != null && (f.ClosedAt == null || f.ClosedAt < DateTime.Now))
            .OrderByDescending(f => f.PublishedAt)
            .ToListAsync();
    }
    public async Task<List<Form>> GetAllByPublishedAtDescAsync()
    {
        return await _context.Forms.OrderByDescending(f => f.PublishedAt).ToListAsync();
    }

    public async Task<Form> GetByIdAsync(int id)
    {
        Form form = await _context.Forms.Include(f => f.Questions).ThenInclude(q => q.InputType)
                                        .Include(f => f.Questions).ThenInclude(q => q.Fields)
                                        .FirstOrDefaultAsync(f => f.Id == id) ?? throw new FormNotFoundException();
        return form;
    }

    public async Task<Form> UpdateAsync(Form form)
    {
        Form formToUpdate = await _context.Forms.FirstOrDefaultAsync(f => f.Id == form.Id) ?? throw new FormNotFoundException();

        formToUpdate.Title = form.Title;
        formToUpdate.Description = form.Description;
        formToUpdate.PublishedAt = form.PublishedAt;
        formToUpdate.ClosedAt = form.ClosedAt;
        formToUpdate.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return formToUpdate;
    }
}
