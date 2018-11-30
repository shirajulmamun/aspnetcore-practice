using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Repository;
using EmployeeManagemetApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EmployeeManagemetApp.Controllers
{
    public class EmployeeController:Controller
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            bool isSaved  =  _employeeRepository.Add(model);
            if (isSaved)
            {
                ViewBag.Message = "Saved Succesful!";
            }
            return View();
        }
    }
}
