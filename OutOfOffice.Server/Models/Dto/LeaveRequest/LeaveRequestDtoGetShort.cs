using OutOfOffice.Server.Models.Dto.Employee;
using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Models.Dto.LeaveRequest
{
    public class LeaveRequestDtoGetShort
    {
        public int Id { get; set; }
        public LeaveStatus Status { get; set; }
        public LeaveReason Reason { get; set; }
        public string? Comment { get; set; }

        public EmployeeDtoGetShort? EmployeeRef { get; set; }
    }
}
