using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Server.Models
{
    public class ApprovalRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ApprovalRequestStatus Status { get; set; }

        [Required]
        public int LeaveRequest { get; set; }
        [ForeignKey("LeaveRequest")]
        public LeaveRequest? LeaveRequestRef { get; set; }

        [Required]
        public int Approver { get; set; }
        [ForeignKey("Approver")]
        public Employee? ApproverRef { get; set; }
    }
}
