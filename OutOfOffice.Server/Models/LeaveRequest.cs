using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Server.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public LeaveStatus Status { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public LeaveReason Reason { get; set; }
        public string? Comment { get; set; }

        [Required]
        public int Employee { get; set; }
        [ForeignKey("Employee")]
        public Employee? EmployeeRef { get; set; }

        public ICollection<ApprovalRequest>? ApprovalRequests { get; set; }
    }
}
