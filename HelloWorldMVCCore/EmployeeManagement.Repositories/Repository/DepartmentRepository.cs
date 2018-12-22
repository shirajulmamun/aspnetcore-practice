﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories.Repository
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
      
    }
}
