using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Business;
public interface IFormBusiness
{
    /// <summary>
    /// Create a new form.
    /// </summary>
    /// <returns>Id of new form.</returns>
    Task<int> CreateAsync();
}
