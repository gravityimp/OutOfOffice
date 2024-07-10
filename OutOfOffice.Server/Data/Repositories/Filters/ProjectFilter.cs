using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Data.Repositories.Filters
{
    public class ProjectFilter
    {
        public int? Id { get; set; }
        public List<ProjectStatus> Statuses { get; set; } = [];
        public List<ProjectType> ProjectTypes { get; set; } = [];
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? ProjectManagerId { get; set; }
        public string? ProjectManagerName { get; set; }

    }
}
