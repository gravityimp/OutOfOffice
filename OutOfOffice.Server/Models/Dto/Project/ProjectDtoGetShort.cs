using OutOfOffice.Server.Models.Dto.Employee;
using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Models.Dto.Project
{
    public class ProjectDtoGetShort
    {
        public int Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public ProjectStatus Status { get; set; }

        public EmployeeDtoGetShort ProjectManager { get; set; }
    }
}
