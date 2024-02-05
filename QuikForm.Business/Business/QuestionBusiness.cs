using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Mappers.Questions;
using QuikForm.Business.Contracts.Responses.Questions;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class QuestionBusiness : IQuestionBusiness
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IInputTypeRepository _inputTypeRepository;
    private readonly IFieldRepository _fieldRepository;
    private readonly IQuestionMapper _questionMapper;

    public QuestionBusiness(IQuestionRepository questionRepository, IInputTypeRepository inputTypeRepository, IFieldRepository fieldRepository, IQuestionMapper questionMapper)
    {
        _questionRepository = questionRepository;
        _inputTypeRepository = inputTypeRepository;
        _fieldRepository = fieldRepository;
        _questionMapper = questionMapper;
    }

    public async Task<QuestionResponse> CreateAsync(int formId)
    {
        Question question = new Question { FormId = formId, InputTypeId = 1, IsMandatory = false };
        Question questionWithInputType = await _questionRepository.CreateAsync(question);
        QuestionResponse questionResponseWithInputType = _questionMapper.ToQuestionResponse(questionWithInputType);
        return questionResponseWithInputType;
    }

    public async Task DeleteAsync(int id)
    {
        await _questionRepository.DeleteAsync(id);
    }

    public async Task DeleteFieldsAsync(int id)
    {
        await _questionRepository.DeleteFieldsAsync(id);
    }


    public async Task<QuestionResponse> GetByIdAsync(int id)
    {
        Question question = await _questionRepository.GetByIdAsync(id);
        QuestionResponse questionResponse = _questionMapper.ToQuestionResponse(question);
        return questionResponse;
    }

    public async Task<QuestionResponse> UpdateLabelAsync(int id, string label)
    {
        Question question = await _questionRepository.GetByIdAsync(id);
        question.Label = label;
        await _questionRepository.UpdateAsync(question);
        QuestionResponse questionResponse = _questionMapper.ToQuestionResponse(question);
        return questionResponse;
    }

    public async Task<QuestionResponse> UpdateInputTypeAsync(int id, string inputTypeMarkup)
    {
        Question question = await _questionRepository.GetByIdAsync(id);
        InputType inputType = await _inputTypeRepository.GetByMarkupAsync(inputTypeMarkup);
        question.InputType = inputType;
        await _questionRepository.UpdateAsync(question);
        QuestionResponse questionResponse = _questionMapper.ToQuestionResponse(question);
        return questionResponse;
    }

    public async Task<QuestionResponse> UpdateIsMandatoryAsync(int id, bool isMandatory)
    {
        Question question = await _questionRepository.GetByIdAsync(id);
        question.IsMandatory = isMandatory;
        await _questionRepository.UpdateAsync(question);
        QuestionResponse questionResponse = _questionMapper.ToQuestionResponse(question);
        return questionResponse;
    }
}
