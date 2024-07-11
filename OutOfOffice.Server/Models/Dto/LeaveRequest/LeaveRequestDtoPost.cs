using OutOfOffice.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Server.Models.Dto.LeaveRequest
{
    public class LeaveRequestDtoPost
    {
        public int Id { get; } = 0;
        [Required]
        public LeaveReason Reason { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        public string? Comment {  get; set; }
    }
}
