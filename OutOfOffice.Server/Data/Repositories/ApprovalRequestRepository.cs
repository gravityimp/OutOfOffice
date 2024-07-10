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
    public class ApprovalRequestRepository : IApprovalRequestRepository
    {
        private readonly OutOfOfficeDbContext _context;

        public ApprovalRequestRepository(OutOfOfficeDbContext context)
        {
            _context = context;
        }

        public async Task<PageResponse<ApprovalRequest>> Get(Pagination pagination, ApprovalRequestFilter filter)
        {
            var query = _context.ApprovalRequests.AsQueryable();

            /* Apply Filtering */

            // Pagination
            var totalEntries = await query.CountAsync();
            var result = await query
                .Skip((pagination.Page - 1) * pagination.Count)
                .Take(pagination.Count)
                .ToListAsync();

            return new PageResponse<ApprovalRequest>
            {
                Data = result,
                Page = pagination.Page,
                TotalPages = (int)Math.Ceiling(totalEntries / (double)pagination.Count),
                TotalEntries = totalEntries
            };
        }

        public async Task<ApprovalRequest> GetById(int id)
        {
            return await _context.ApprovalRequests.FindAsync(id);
        }

        public async Task Create(ApprovalRequest approvalRequest)
        {
            _context.ApprovalRequests.Add(approvalRequest);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ApprovalRequest approvalRequest)
        {
            _context.Entry(approvalRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var request = await _context.Projects.FindAsync(id);
            if (request != null)
            {
                _context.Projects.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
