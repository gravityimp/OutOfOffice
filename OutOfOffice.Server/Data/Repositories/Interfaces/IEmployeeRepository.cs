using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee, EmployeeFilter>
    {
    }
}
