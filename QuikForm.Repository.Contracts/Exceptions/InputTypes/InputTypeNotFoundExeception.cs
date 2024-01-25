using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Exceptions.InputTypes;
public class InputTypeNotFoundException : Exception
{
    public override string Message => "InputType is not found.";
}
