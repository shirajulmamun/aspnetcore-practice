﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagemetApp.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string RegNo { get; set; }
        [Required]
        public double Salary { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        [Display(Name = "Department")]
        [Required]
        public int? DepartmentId { get; set; }
        
        public  List<SelectListItem> Departments { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
