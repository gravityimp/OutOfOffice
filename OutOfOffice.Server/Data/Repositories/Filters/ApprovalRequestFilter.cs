using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Data.Repositories.Filters
{
    public class ApprovalRequestFilter
    {
        public int? Id { get; set; }
        public List<ApprovalRequestStatus> Statuses { get; set; } = [];
        public int? LeaveRequestId { get; set; }
        public int? ApproverId { get; set; }
        public string? ApproverName { get; set; }
    }
}
