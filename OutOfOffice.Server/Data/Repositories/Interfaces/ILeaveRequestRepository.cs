using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Data.Repositories.Interfaces
{
    public interface ILeaveRequestRepository : IRepository<LeaveRequest, LeaveRequestFilter>
    {
    }
}
