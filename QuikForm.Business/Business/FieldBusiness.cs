using QuikForm.Business.Contracts.Business;
using QuikForm.Repository.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class FieldBusiness : IFieldBusiness
{
    private readonly IFieldRepository _fieldRepository;

    public FieldBusiness(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }
}
