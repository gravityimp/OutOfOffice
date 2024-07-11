using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Models;
using OutOfOffice.Server.Models.Dto.Employee;

namespace OutOfOffice.Server.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee, EmployeeFilter>
    {
        public new Task<PageResponse<EmployeeDtoGet>> Get(Pagination pagination, EmployeeFilter employeeFilter);
    }
}