using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Data.Responses.Interfaces;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Data.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly OutOfOfficeDbContext _context;

        public LeaveRequestRepository(OutOfOfficeDbContext context)
        {
            _context = context;
        }

        public async Task<PageResponse<LeaveRequest>> Get(Pagination pagination, LeaveRequestFilter filter)
        {
            var query = _context.LeaveRequests.AsQueryable();

            /* Apply Filtering */

            // Filter Id
            if (filter.Id.HasValue)
            {
                query = query.Where(lr => lr.Id == filter.Id);
            }

            // Filter Status
            if (!filter.Statuses.IsNullOrEmpty())
            {
                query = query.Where(lr => filter.Statuses.Contains(lr.Status));
            }

            // Filter Leave Reason
            if (!filter.LeaveReasons.IsNullOrEmpty())
            {
                query = query.Where(lr => filter.LeaveReasons.Contains(lr.Reason));
            }

            // Filter Start Date
            if (filter.StartDate.HasValue)
            {
                query = query.Where(lr => lr.StartDate == filter.StartDate);
            }

            // Filter End Date
            if (filter.EndDate.HasValue)
            {
                query = query.Where(lr => lr.EndDate == filter.EndDate);
            }

            // Filter Employee Id or Employee Name
            if (filter.EmployeeId.HasValue)
            {
                query = query.Where(lr => lr.Employee == filter.EmployeeId);
            }
            else if (!string.IsNullOrEmpty(filter.EmployeeName))
            {
                query = query.Where(lr => lr.EmployeeRef.FullName.ToLower().Contains(filter.EmployeeName.ToLower()));
            }

            // Pagination
            var totalEntries = await query.CountAsync();
            var result = await query
                .Skip((pagination.Page - 1) * pagination.Count)
                .Take(pagination.Count)
                .ToListAsync();

            return new PageResponse<LeaveRequest>
            {
                Data = result,
                Page = pagination.Page,
                TotalPages = (int)Math.Ceiling(totalEntries / (double)pagination.Count),
                TotalEntries = totalEntries
            };
        }

        public async Task<LeaveRequest> GetById(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task Create(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LeaveRequest leaveRequest)
        {
            _context.Entry(leaveRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var request = await _context.LeaveRequests.FindAsync(id);
            if (request != null)
            {
                _context.LeaveRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
