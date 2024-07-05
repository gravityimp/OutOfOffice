namespace OutOfOffice.Server.Models
{
    public class ApprovalRequest
    {
        public int ApprovalRequestId { get; set; }
        public int LeaveRequestId { get; set; }
        public int ApproverId { get; set; }
        public bool Approved { get; set; }
        public LeaveRequest LeaveRequest { get; set; }
        public Employee Approver { get; set; }
    }
}
