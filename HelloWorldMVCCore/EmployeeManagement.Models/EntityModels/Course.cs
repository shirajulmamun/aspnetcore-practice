﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models.EntityModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Department Department { get; set; }
    }
}
