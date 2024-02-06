using QuikForm.Business.Contracts.Mappers.Fields;
using QuikForm.Business.Contracts.Mappers.InputTypes;
using QuikForm.Business.Contracts.Responses.Questions;
using QuikForm.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Mappers.Questions;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class QuestionMapper : IQuestionMapper
{
    private partial QuestionResponse ToQuestionResponsePartial(Question question);

    public partial Question ToQuestion(QuestionResponse questionResponse);

    public QuestionResponse ToQuestionResponse(Question question)
    {
        FieldMapper fieldMapper = new FieldMapper();
        InputTypeMapper inputTypeMapper = new InputTypeMapper();
        QuestionResponse dto = ToQuestionResponsePartial(question);
        if (question.Fields != null)
        {
            dto.FieldResponses = question.Fields.Select(q => fieldMapper.ToFieldResponse(q)).ToList();
        }
        if (question.InputType != null)
        {
            dto.InputTypeResponse = inputTypeMapper.ToInputTypeResponse(question.InputType);
        }
        return dto;
    }
}
