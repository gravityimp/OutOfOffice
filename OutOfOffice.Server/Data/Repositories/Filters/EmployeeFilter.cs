using OutOfOffice.Server.Models;
using OutOfOffice.Server.Models.Enums;

namespace OutOfOffice.Server.Data.Repositories.Filters
{
    public class EmployeeFilter
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public List<Subdivision> Subdivisions { get; set; } = [];
        public List<Position> Positions { get; set; } = [];
        public List<EmployeeStatus> Statuses { get; set; } = [];
        public int? PeoplePartnerId { get; set; }
        public string? PeoplePartnerName { get; set; }
    }
}
