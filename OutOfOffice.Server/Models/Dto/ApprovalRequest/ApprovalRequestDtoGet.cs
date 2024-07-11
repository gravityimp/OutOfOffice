using OutOfOffice.Server.Models.Dto.Employee;
using OutOfOffice.Server.Models.Dto.LeaveRequest;
using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Models.Dto.ApprovalRequest
{
    public class ApprovalRequestDtoGet
    {
        public int Id { get; set; }
        public ApprovalRequestStatus Status { get; set; }
        
        public required LeaveRequestDtoGetShort LeaveRequest { get; set; }
        public required EmployeeDtoGetShort Approver { get; set; }
    }
}
