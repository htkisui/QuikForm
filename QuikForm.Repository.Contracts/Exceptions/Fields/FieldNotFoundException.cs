using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Exceptions.Fields;
public class FieldNotFoundException : Exception
{
    public override string Message => "Field is not found.";
}
