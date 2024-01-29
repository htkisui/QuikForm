using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Entities;
public class ApplicationUser : IdentityUser<int>
{
    public List<Form> Forms { get; set; } = [];
}
