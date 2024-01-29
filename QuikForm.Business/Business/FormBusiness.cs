using QuikForm.Business.Contracts.Business;
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
}
