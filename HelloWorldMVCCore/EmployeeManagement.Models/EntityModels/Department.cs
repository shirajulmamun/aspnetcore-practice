﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.EntityModels
{
    public class Department
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
