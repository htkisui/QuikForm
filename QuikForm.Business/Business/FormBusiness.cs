using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
    private readonly IQuestionRepository _questionRepository;
    private readonly IFieldRepository _fieldRepository;

    public FormBusiness(IFormRepository formRepository, IQuestionRepository questionRepository, IFieldRepository fieldRepository)
    {
        _formRepository = formRepository;
        _questionRepository = questionRepository;
        _fieldRepository = fieldRepository;
    }

    public async Task CloneAsync(int id)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        Form formToClone = new Form() { Title = form.Title, Description = form.Description };
        await _formRepository.CreateAsync(formToClone);
        foreach (Question question in form.Questions)
        {
            Question questionToClone = new Question() { Label = question.Label, FormId = formToClone.Id, InputTypeId = question.InputTypeId };
            await _questionRepository.CreateAsync(questionToClone);
            foreach (Field field in question.Fields)
            {
                Field fieldToClone = new Field() { Label = field.Label, QuestionId = questionToClone.Id };
                await _fieldRepository.CreateAsync(fieldToClone);
            }
        }
    }

    public async Task<Form> CreateAsync()
    {
        Form form = new Form { };
        await _formRepository.CreateAsync(form);
        return form;
    }

    public async Task DeleteAsync(int id)
    {
        await _formRepository.DeleteAsync(id);
    }

    public async Task<List<Form>> GetAllAsync()
    {
        return await _formRepository.GetAllAsync();
    }

    public async Task<List<Form>> GetAllClosedByClosedAtDescAsync()
    {
        List<Form> formsClosedAt = await _formRepository.GetAllClosedByClosedAtDescAsync();
        return formsClosedAt;
    }

    public async Task<List<Form>> GetAllPublishedAndNotClosedByPublishedAtDescAsync()
    {
        List<Form> formsPublishedAt = await _formRepository.GetAllPublishedAndNotClosedByPublishedAtDescAsync();
        return formsPublishedAt;
    }

    public async Task<Form> GetByIdAsync(int id)
    {
        return await _formRepository.GetByIdAsync(id);
    }

    public async Task UpdateClosedAt(int id)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        form.ClosedAt = DateTime.Now;
        await _formRepository.UpdateAsync(form);
    }

    public async Task UpdateDescriptionAsync(int id, string description)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        form.Description = description;
        await _formRepository.UpdateAsync(form);
    }

    public async Task UpdatePublishedAt(int id)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        form.PublishedAt = DateTime.Now;
        await _formRepository.UpdateAsync(form);
    }

    public async Task UpdateTitleAsync(int id, string title)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        form.Title = title;
        await _formRepository.UpdateAsync(form);
    }
}