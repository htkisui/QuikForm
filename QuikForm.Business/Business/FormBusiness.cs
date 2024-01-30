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

    public async Task<int> CreateAsync()
    {
        Form form = new Form { };
        await _formRepository.CreateAsync(form);
        return form.Id;
    }
}