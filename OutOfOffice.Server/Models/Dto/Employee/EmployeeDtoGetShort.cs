using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Models.Dto.Employee
{
    public class EmployeeDtoGetShort
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public EmployeeStatus Status { get; set; }
        public byte[]? Photo { get; set; }
    }
}
