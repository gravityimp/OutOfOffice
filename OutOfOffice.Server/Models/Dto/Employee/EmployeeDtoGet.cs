using OutOfOffice.Server.Models.Dto.Project;
using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Server.Models.Dto.Employee
{
    public class EmployeeDtoGet
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Subdivision Subdivision { get; set; }
        public Position Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public int OutOfOfficeBalance { get; set; }
        public byte[]? Photo { get; set; } = null;

        public EmployeeDtoGetShort PeoplePartner { get; set; }
        public ICollection<ProjectDtoGetShort> Projects { get; set; } = [];
        public ICollection<ProjectDtoGetShort> ManagedProjects { get; set; } = [];
    }
}
