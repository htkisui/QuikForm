using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Contracts;
public interface IQuestionRepository
{
    /// <summary>
    /// Create a new question.
    /// </summary>
    /// <param name="question"></param>
    /// <returns>The question with its InputType</returns>
    Task<Question> CreateAsync(Question question);

    /// <summary>
    /// Delete a question and its fields.
    /// </summary>
    /// <param name="id"></param>
    Task DeleteAsync(int id);

    /// <summary>
    /// Get all questions of a form with their fields.
    /// </summary>
    /// <returns>List of questions.</returns>
    Task<List<Question>> GetAllAsync();

    /// <summary>
    /// Get a question by Id with its fields.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Question.</returns>
    Task<Question> GetByIdAsync(int id);

    /// <summary>
    /// Update a question.
    /// </summary>
    /// <param name="question"></param>
    /// <returns>Question updated.</returns>
    Task<Question> UpdateAsync(Question question);
}
