using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Contracts;
using EmployeeManagement.Models.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagemetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }


        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeManager.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return _employeeManager.GetById(id);
        }
       
        [Route("[action]")]
        [HttpGet("{departmentId}")]
        public List<Employee> GetByDepartment([FromQuery]int departmentId)
        {
            return _employeeManager.GetByDepartment(departmentId);
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _employeeManager.Add(employee);
                if (isAdded)
                {
                    return Ok(employee);
                }

                
            }

            return BadRequest(ModelState);

        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
