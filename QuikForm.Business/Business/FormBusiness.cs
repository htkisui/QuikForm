using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Mappers.Fields;
using QuikForm.Business.Contracts.Mappers.Forms;
using QuikForm.Business.Contracts.Mappers.Questions;
using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.Business.Contracts.Responses.Questions;
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
    private readonly IFieldRecordRepository _fieldRecordRepository;
    private readonly IFieldMapper _fieldMapper;
    private readonly IQuestionMapper _questionMapper;

    public FormBusiness(IFormRepository formRepository, IQuestionRepository questionRepository, IFieldRepository fieldRepository, IFormMapper formMapper, IFieldRecordRepository fieldRecordRepository, IFieldMapper fieldMapper, IQuestionMapper questionMapper)
    {
        _formRepository = formRepository;
        _questionRepository = questionRepository;
        _fieldRepository = fieldRepository;
        _formMapper = formMapper;
        _fieldRecordRepository = fieldRecordRepository;
        _fieldMapper = fieldMapper;
        _questionMapper = questionMapper;
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

    public async Task<List<FormResponse>> GetAllByTitleAsync(string title)
    {
        List<Form> forms = await _formRepository.GetAllByTitleAsync(title);
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

    public async Task<FormResponse> GetResultAsync(int id)
    {
        Form form = await _formRepository.GetByIdAsync(id);
        FormResponse formResponse = _formMapper.ToFormResponse(form);
        foreach(QuestionResponse questionResponse in formResponse.QuestionResponses)
        {   
            int totalCount = 0;
            foreach(FieldResponse fieldResponse in questionResponse.FieldResponses)
            {
                int count = await _fieldRecordRepository.CountAsync(fieldResponse.Id);
                totalCount += count;
                fieldResponse.Count = count;
            }

            foreach(FieldResponse fieldResponse in questionResponse.FieldResponses)
            {
                if (totalCount == 0) fieldResponse.Percent = 0;
                else fieldResponse.Percent = ((float) fieldResponse.Count) / totalCount * 100;
            }
        }
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