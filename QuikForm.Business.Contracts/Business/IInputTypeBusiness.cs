﻿using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Contracts.Business;
public interface IInputTypeBusiness
{
    Task<List<InputType>> GetAllAsync();
}