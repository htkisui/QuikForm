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
    public partial QuestionResponse ToQuestionResponse(Question question);

    private partial Question ToQuestionPartial(QuestionResponse questionResponse);

    public Question ToQuestion(QuestionResponse questionResponse)
    {
        var fieldMapper = new FieldMapper();
        var inputTypeMapper = new InputTypeMapper();
        var dto = ToQuestionPartial(questionResponse);
        if (questionResponse.FieldResponses != null)
        {
            dto.Fields = questionResponse.FieldResponses.Select(q => fieldMapper.ToField(q)).ToList();
        }
        if (questionResponse.InputTypeResponse != null)
        {
            dto.InputType = inputTypeMapper.ToInputType(questionResponse.InputTypeResponse);
        }
        return dto;
    }
}
