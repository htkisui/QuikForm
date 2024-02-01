using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Business;
public interface IQuestionBusiness
{
    /// <summary>
    /// Create a new question.
    /// </summary>
    /// <returns>Id of new question.</returns>
    Task<int> CreateAsync();

    Task<Question> GetByIdAsync(int id);
}
