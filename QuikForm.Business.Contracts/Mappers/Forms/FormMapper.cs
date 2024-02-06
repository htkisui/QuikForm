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
    public partial Form ToForm(FormResponse formResponse);

    private partial FormResponse ToFormResponsePartial(Form form);

    public FormResponse ToFormResponse(Form form)
    {
        var questionMapper = new QuestionMapper();
        var dto = ToFormResponsePartial(form);
        if (form.Questions != null)
        {
            dto.QuestionResponses = form.Questions.Select(f => questionMapper.ToQuestionResponse(f)).ToList();
        }

        return dto;
    }
}
