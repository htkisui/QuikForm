using QuikForm.Business.Contracts.Mappers.Questions;
using QuikForm.Business.Contracts.Responses.Forms;
using QuikForm.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Mappers.Forms;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FormMapper : IFormMapper
{
    public partial FormResponse ToFormResponse(Form form);

    private partial Form ToFormPartial(FormResponse formResponse);

    public Form ToForm(FormResponse formResponse)
    {
        var questionMapper = new QuestionMapper();
        var dto = ToFormPartial(formResponse);
        if (formResponse.QuestionResponses != null)
        {
            dto.Questions = formResponse.QuestionResponses.Select(f => questionMapper.ToQuestion(f)).ToList();
        }

        return dto;
    }
}
