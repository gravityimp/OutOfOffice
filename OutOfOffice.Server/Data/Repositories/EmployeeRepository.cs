using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Models;
using OutOfOffice.Server.Models.Dto.Employee;

namespace OutOfOffice.Server.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OutOfOfficeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(OutOfOfficeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PageResponse<EmployeeDtoGet>> Get(Pagination pagination, EmployeeFilter employeeFilter)
        {
            var query = _context.Employees.AsQueryable();

            /* Filtering */

            // Filter Employee Id
            if (employeeFilter.Id.HasValue)
            {
                query = query.Where(e => e.Id == employeeFilter.Id);
            }

            // Filter Employee Name
            if (!string.IsNullOrEmpty(employeeFilter.FullName))
            {
                query = query.Where(e => e.FullName.ToLower().Contains(employeeFilter.FullName.ToLower()));
            }

            // Filter Employee Subdivision
            if (!employeeFilter.Subdivisions.IsNullOrEmpty())
            {
                query = query.Where(e => employeeFilter.Subdivisions.Contains(e.Subdivision));
            }

            // Filter Employee Position
            if (!employeeFilter.Positions.IsNullOrEmpty())
            {
                query = query.Where(e => employeeFilter.Positions.Contains(e.Position));
            }

            // Filter Employee Status
            if (!employeeFilter.Statuses.IsNullOrEmpty())
            {
                query = query.Where(e => employeeFilter.Statuses.Contains(e.Status));
            }

            // Filter Partner Id
            if (employeeFilter.PeoplePartnerId.HasValue)
            {
                query = query.Where(e => e.PeoplePartner == employeeFilter.PeoplePartnerId);
            }

            // Filter Partner Name
            if (!string.IsNullOrEmpty(employeeFilter.PeoplePartnerName))
            {
                query = query.Where(e => e.PeoplePartnerRef.FullName.ToLower().Contains(employeeFilter.PeoplePartnerName.ToLower()));
            }

            // Apply pagination
            var totalEntries = await query.CountAsync();
            var entries = await query
                .Skip((pagination.Page - 1) * pagination.Count)
                .Take(pagination.Count)
                .ToListAsync();

            var result = _mapper.Map<List<EmployeeDtoGet>>(entries);

            // Generate Pagination Response
            return new PageResponse<EmployeeDtoGet>
            {
                Data = result,
                Page = pagination.Page,
                TotalPages = (int)Math.Ceiling(totalEntries / (double)pagination.Count),
                TotalEntries = totalEntries
            };
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.PeoplePartnerRef)
                .FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
