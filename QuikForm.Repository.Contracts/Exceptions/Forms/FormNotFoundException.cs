using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Exceptions.Forms;
public class FormNotFoundException : Exception
{
    public override string Message => "Form is not found.";
}
