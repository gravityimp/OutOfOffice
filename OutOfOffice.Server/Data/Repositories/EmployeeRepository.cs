using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OutOfOfficeDbContext _context;

        public EmployeeRepository(OutOfOfficeDbContext context)
        {
            _context = context;
        }

        public async Task<PageResponse<Employee>> Get(Pagination pagination, EmployeeFilter employeeFilter)
        {
            var query = _context.Employees.AsQueryable();

            /* Filtering */

            // Employee Id Filter
            if (employeeFilter.Id != null)
            {
                query = query.Where(e => e.Id == employeeFilter.Id);
            }

            // Employee Name Filter
            if (!string.IsNullOrEmpty(employeeFilter.FullName))
            {
                query = query.Where(e => e.FullName.Contains(employeeFilter.FullName));
            }

            // Employee Subdivision Filter
            if (employeeFilter.Subdivisions != null && employeeFilter.Subdivisions.Count > 0)
            {
                query = query.Where(e => employeeFilter.Subdivisions.Contains(e.Subdivision));
            }

            // Employee Position Filter
            if (employeeFilter.Positions != null && employeeFilter.Positions.Count > 0)
            {
                query = query.Where(e => employeeFilter.Positions.Contains(e.Position));
            }

            // Employee Status Filter
            if (employeeFilter.Statuses != null && employeeFilter.Statuses.Count > 0)
            {
                query = query.Where(e => employeeFilter.Statuses.Contains(e.Status));
            }

            // Partner Id Filter
            if (employeeFilter.PeoplePartnerId != null)
            {
                query = query.Where(e => e.PeoplePartner == employeeFilter.PeoplePartnerId);
            }

            // Partner Name Filter
            if (!string.IsNullOrEmpty(employeeFilter.PeoplePartnerName))
            {
                query = query.Where(e => e.PeoplePartnerRef.FullName.Contains(employeeFilter.PeoplePartnerName));
            }

            // Apply pagination
            var totalEntries = await query.CountAsync();
            var result = await query
                .Skip((pagination.Page - 1) * pagination.Count)
                .Take(pagination.Count)
                .ToListAsync();

            // Generate Pagination Response
            return new PageResponse<Employee>
            {
                Data = result,
                Page = pagination.Page,
                TotalPages = (int)Math.Ceiling(totalEntries / (double)pagination.Count),
                TotalEntries = totalEntries
            };
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
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
