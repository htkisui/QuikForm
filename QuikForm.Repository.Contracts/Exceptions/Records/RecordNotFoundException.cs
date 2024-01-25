using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Exceptions.Records;
public class RecordNotFoundException : Exception
{
    public override string Message => "Record is not found.";
}
