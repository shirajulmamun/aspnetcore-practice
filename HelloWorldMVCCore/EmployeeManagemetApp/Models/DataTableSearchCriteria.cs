using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagemetApp.Models
{
    public class DataTableSearchCriteria
    {
        public int? Draw { get; set; }
        public int? Start { get; set; }
        public int? Length { get; set; }
        public EmployeeSearchCriteria SearchCriteria { get; set; }
    }
}
