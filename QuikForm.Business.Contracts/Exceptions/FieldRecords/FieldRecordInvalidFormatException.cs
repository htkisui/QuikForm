using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Exceptions.FieldRecords;
public class FieldRecordInvalidFormatException : Exception
{
    public override string Message => "FieldRecord's format must be like xxx-xxx with 'xxx' the input & question/field's id.";
}
