using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Project> GetById(int id)
        {
            return await _context.Projects.FindAsync(id);
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
