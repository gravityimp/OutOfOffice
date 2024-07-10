using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Server.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
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
        public byte[]? Photo { get; set; }

        [Required]
        public int PeoplePartner { get; set; }
        [ForeignKey("PeoplePartner")]
        public Employee? PeoplePartnerRef { get; set; }

        public ICollection<Project>? Projects { get; set; }
        public ICollection<Project>? ManagedProjects { get; set; }
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
        public ICollection<ApprovalRequest>? ApprovalRequests { get; set; }
    }
}
