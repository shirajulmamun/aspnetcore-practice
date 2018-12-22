using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.BLL.Contracts;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;

namespace EmployeeManagement.BLL.Managers
{
   public class ContractManager:Manager<Contract>,IContractManager
    {
        public ContractManager(IContractRepository repository) : base(repository)
        {
        }
    }
}
