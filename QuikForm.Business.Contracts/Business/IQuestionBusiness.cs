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
    Task<Question> CreateAsync(int formId);

    /// <summary>
    /// Deleted a question ans its fields.
    /// </summary>
    /// <param name="id"></param>
    Task DeleteAsync(int id);

    /// <summary>
    /// Delete a question's field by question id.
    /// </summary>
    /// <param name="id"></param>
    Task DeleteFieldsAsync(int id);

    /// <summary>
    /// Get a question by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The question with its InputType.</returns>
    Task<Question> GetByIdAsync(int id);

    /// <summary>
    /// Update the Label of the question selected by.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="label"></param>
    /// <returns>Question updated.</returns>
    Task<Question> UpdateLabelAsync(int id, string label);

    /// <summary>
    /// Update the inputType of the question selected by.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="inputType"></param>
    /// <returns>Question updated.</returns>
    Task<Question> UpdateInputTypeAsync(int id, string inputTypeMarkup);

    /// <summary>
    /// Update the isMandatory of the question selected by.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isMandatory"></param>
    /// <returns>Question updated.</returns>
    Task<Question> UpdateIsMandatoryAsync(int id, bool isMandatory);


}

