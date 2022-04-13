namespace HRMS.Domain.Entities
{
    public class UserLeavePolicy
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public int LeavePolicyId { get; set; }
        public LeavePolicy LeavePolicy { get; set; }
    }
}
