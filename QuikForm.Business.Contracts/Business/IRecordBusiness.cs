using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Business;
public interface IRecordBusiness
{
    /// <summary>
    /// Create a new record.
    /// </summary>
    /// <param name="records"></param>
    Task CreateAsync(Dictionary<string, string> records);
}
