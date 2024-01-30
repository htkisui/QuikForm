using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class InputTypeBusiness : IInputTypeBusiness
{
    private readonly IInputTypeRepository _inputTypeRepository;

    public InputTypeBusiness(IInputTypeRepository inputTypeRepository)
    {
        _inputTypeRepository = inputTypeRepository;
    }

    public async Task<List<InputType>> GetAllAsync()
    {
        return await _inputTypeRepository.GetAllAsync();
    } 
}
