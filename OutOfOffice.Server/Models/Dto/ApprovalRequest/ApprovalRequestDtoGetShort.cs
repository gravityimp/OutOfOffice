using OutOfOffice.Server.Models.Dto.Employee;
using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Models.Dto.ApprovalRequest
{
    public class ApprovalRequestDtoGetShort
    {
        public required int Id { get; set; }
        public required ApprovalRequestStatus Status { get; set; }
        public required EmployeeDtoGetShort Approver { get; set; }
    }
}
