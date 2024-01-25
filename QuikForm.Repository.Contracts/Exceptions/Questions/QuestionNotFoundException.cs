using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Exceptions.Questions;
public class QuestionNotFoundException : Exception
{
    public override string Message => "Question is not found.";
}
