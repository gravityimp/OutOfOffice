using OutOfOffice.Server.Utils.Enums;

namespace OutOfOffice.Server.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveReason Reason { get; set; }
        public string? Comment { get; set; }
        public LeaveStatus Status { get; set; }

        public Employee Employee { get; set; }
        public ICollection<ApprovalRequest> ApprovalRequests { get; set; }
    }
}
