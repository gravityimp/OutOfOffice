using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Server.Models.Dto.Employee
{
    public class EmployeeDtoPost
    {
        public int Id { get; } = 0;
        [Required]
        public string FullName { get; set; }
        [Required]
        public Subdivision Subdivision { get; set; }
        [Required]
        public Position Position { get; set; }
        [Required]
        public EmployeeStatus Status { get; set; }
        [Required]
        public int OutOfOfficeBalance { get; set; }
        [Required]
        public int PeoplePartner { get; set; }
        public byte[]? Photo { get; set; }
    }
}
