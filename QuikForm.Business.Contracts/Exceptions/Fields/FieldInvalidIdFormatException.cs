using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Exceptions.Fields;
public class FieldInvalidIdFormatException : Exception
{
    public override string Message => "Field's id must be an int.";
}
