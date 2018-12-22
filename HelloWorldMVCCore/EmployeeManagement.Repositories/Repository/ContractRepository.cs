using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories.Repository
{
    public class ContractRepository:Repository<Contract>,IContractRepository
    {
        public override ICollection<Contract> GetAll()
        {
            return db.Contracts.Include(c => c.Employee).ToList();
        }

        public override Contract GetById(int id)
        {
            return db.Contracts.Include(c => c.Employee).FirstOrDefault(c => c.Id == id);
        }
    }
}
