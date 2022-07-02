using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entities
{
    public class WorkHistory
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime StartDate { get; set; }
        public string? Designation { get; set; }
    }
}
