using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models.EntityModels
{
    public class Contract
    {

        public int Id { get; set; }
        public string ContractNo { get; set; }
        public string Details { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
