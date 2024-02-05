using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Mappers.Forms;
using QuikForm.Business.Contracts.Responses.Forms;
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
    private readonly IFormMapper _formMapper;

    public FormBusiness(IFormRepository formRepository, IQuestionRepository questionRepository, IFieldRepository fieldRepository, IFormMapper formMapper)
    {
        _formRepository = formRepository;
        _questionRepository = questionRepository;
        _fieldRepository = fieldRepository;
        _formMapper = formMapper;
    }

    public async Task DuplicateAsync(int id)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        Form formToDuplicate = new Form() { Title = form.Title, Description = form.Description };
        await _formRepository.CreateAsync(formToDuplicate);
        foreach (Question question in form.Questions)
        {
            Question questionToDuplicate = new Question() { Label = question.Label, FormId = formToDuplicate.Id, InputTypeId = question.InputTypeId };
            await _questionRepository.CreateAsync(questionToDuplicate);
            foreach (Field field in question.Fields)
            {
                Field fieldToDuplicate = new Field() { Label = field.Label, QuestionId = questionToDuplicate.Id };
                await _fieldRepository.CreateAsync(fieldToDuplicate);
            }
        }
    }

    public async Task<FormResponse> CreateAsync()
    {
        Form form = new Form { };
        await _formRepository.CreateAsync(form);
        FormResponse formResponse = _formMapper.ToFormResponse(form);
        return formResponse;
    }

    public async Task DeleteAsync(int id)
    {
        await _formRepository.DeleteAsync(id);
    }

    public async Task<List<FormResponse>> GetAllAsync()
    {
        List<Form> forms = await _formRepository.GetAllAsync();
        List<FormResponse> formResponses = forms.Select(f => _formMapper.ToFormResponse(f)).ToList();
        return formResponses;
    }

    public async Task<List<FormResponse>> GetAllClosedByClosedAtDescAsync()
    {
        List<Form> forms = await _formRepository.GetAllClosedByClosedAtDescAsync();
        List<FormResponse> formResponses = forms.Select(f => _formMapper.ToFormResponse(f)).ToList();
        return formResponses;
    }

    public async Task<List<FormResponse>> GetAllPublishedAndNotClosedByPublishedAtDescAsync()
    {
        List<Form> forms = await _formRepository.GetAllPublishedAndNotClosedByPublishedAtDescAsync();
        List<FormResponse> formResponses = forms.Select(f => _formMapper.ToFormResponse(f)).ToList();
        return formResponses;
    }

    public async Task<FormResponse> GetByIdAsync(int id)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        FormResponse formResponse = _formMapper.ToFormResponse(form);
        return formResponse;
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