using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Mappers.Fields;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class FieldMapper : IFieldMapper
{
    public partial FieldResponse ToFieldResponse(Field field);
    public partial Field ToField(FieldResponse fieldResponse);
}
