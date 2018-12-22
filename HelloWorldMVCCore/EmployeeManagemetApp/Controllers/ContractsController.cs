using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.BLL.Contracts;
using EmployeeManagement.BLL.Managers;

namespace EmployeeManagemetApp.Controllers
{
    public class ContractsController : Controller
    {
        private readonly IContractManager _contractManager;
        private IEmployeeManager _employeeManager;

        public ContractsController(IContractManager contractManager,IEmployeeManager employeeManager)
        {
            _contractManager = contractManager;
            _employeeManager = employeeManager;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            var employees = _contractManager.GetAll();
            return View(employees);
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract =  _contractManager.GetById((int)id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_employeeManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractNo,Details,EmployeeId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _contractManager.Add(contract);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_employeeManager.GetAll(), "Id", "Name", contract.EmployeeId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = _contractManager.GetById((int)id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_employeeManager.GetAll(), "Id", "Name", contract.EmployeeId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractNo,Details,EmployeeId")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contractManager.Update(contract);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_employeeManager.GetAll(), "Id", "Name", contract.EmployeeId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = _contractManager.GetById((int)id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract =  _contractManager.GetById(id);
            _contractManager.Remove(contract);
      
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _contractManager.GetAll().Any(e => e.Id == id);
        }
    }
}
