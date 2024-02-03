using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Exceptions.Questions;
public class QuestionInvalidIdFormatException : Exception
{
    public override string Message => "Question's id must be an int.";
}
