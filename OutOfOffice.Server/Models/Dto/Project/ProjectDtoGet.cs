using OutOfOffice.Server.Models.Dto.Employee;
using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Models.Dto.Project
{
    public class ProjectDtoGet
    {
        public int Id { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; } = null;
        public string? Comment = null;

        public EmployeeDtoGetShort ProjectManager { get; set; }
        public ICollection<EmployeeDtoGetShort> Employees { get; set; } = [];
    }
}
