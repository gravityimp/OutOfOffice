namespace OutOfOffice.Server.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
