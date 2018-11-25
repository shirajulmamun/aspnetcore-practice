using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Models.EntityModels;

namespace EmployeeManagement.Models.EntityModels
{


    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Employee Employee { get; set; }
    }

}
