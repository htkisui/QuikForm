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
    /// <param name="fromId"></param>
    /// <returns>The question with its InputType.</returns>
    Task<Question> CreateAsync(int fromId);

    /// <summary>
    /// Deleted a question ans its fields.
    /// </summary>
    /// <param name="id"></param>
    Task DeleteAsync(int id);

    Task<Question> UpdateLabelAsync(int id, string label);

    Task<Question> UpdateIsMandatoryAsync(int id, bool isMandatory);
}

