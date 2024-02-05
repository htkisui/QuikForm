using QuikForm.Business.Contracts.Responses.Fields;
using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Mappers.Fields;
public interface IFieldMapper
{
    FieldResponse ToFieldResponse(Field field);
    Field ToField(FieldResponse fieldResponse);
}
