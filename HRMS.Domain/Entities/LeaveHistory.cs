using System.ComponentModel.DataAnnotations;

namespace HRMS.Domain.Entities
{
    public class LeaveHistory
    {
        public long Id { get; set; }
        public int Status { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Range(0, 366, ErrorMessage = "The {0} must be between {1} and {2}.")]
        public int NoOfLeaves { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
