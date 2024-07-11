using OutOfOffice.Server.Models.Dto.ApprovalRequest;
using OutOfOffice.Server.Models.Dto.Employee;
using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Models.Dto.LeaveRequest
{
    public class LeaveRequestDtoGet
    {
        public int Id { get; set; }
        public LeaveStatus Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public LeaveReason Reason { get; set; }
        public string? Comment { get; set; }

        public required EmployeeDtoGetShort Employee { get; set; }
        public required ICollection<ApprovalRequestDtoGetShort> ApprovalRequests { get; set; }
    }
}
