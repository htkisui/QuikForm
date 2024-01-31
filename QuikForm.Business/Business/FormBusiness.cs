using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class FormBusiness : IFormBusiness
{
    private readonly IFormRepository _formRepository;

    public FormBusiness(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public async Task<Form> CreateAsync()
    {
        Form form = new Form { };
        await _formRepository.CreateAsync(form);
        return form;
    }

    public async Task<List<Form>> GetAllAsync()
    {
        return await _formRepository.GetAllAsync();
    }

    public async Task<Form> GetByIdAsync(int id)
    {
        return await _formRepository.GetByIdAsync(id);
    }

    public async Task UpdateDescriptionAsync(int id, string description)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        form.Description = description;
        await _formRepository.UpdateAsync(form);
    }

    public async Task UpdateTitleAsync(int id, string title)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        form.Title = title;
        await _formRepository.UpdateAsync(form);
    }
}