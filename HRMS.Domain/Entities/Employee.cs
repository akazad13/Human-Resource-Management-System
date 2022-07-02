using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string? Designation { get; set; }
        public long? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<EmployeeLeavePolicy>? EmployeeLeavePolicies { get; set; }
        public ICollection<LeaveHistory>? LeaveHistories { get; set; }
        public ICollection<WorkHistory>? WorkHistories { get; set; }
    }
}
