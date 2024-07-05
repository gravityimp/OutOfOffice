using OutOfOffice.Server.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Subdivision { get; set; }
        public int Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public int PeoplePartnerId { get; set; }
        public int OutOfOfficeBalance { get; set; }
        public byte[] Photo { get; set; }

        public Employee PeopleParter { get; set; }
    }
}
