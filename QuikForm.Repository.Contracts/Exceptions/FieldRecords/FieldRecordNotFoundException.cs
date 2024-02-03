using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repository.Contracts.Exceptions.FieldRecords;
public class FieldRecordNotFoundException : Exception
{
    public override string Message => "FieldRecord is not found.";
}
