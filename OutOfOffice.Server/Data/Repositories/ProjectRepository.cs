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
    public class ProjectRepository : IProjectRepository
    {
        private readonly OutOfOfficeDbContext _context;

        public ProjectRepository(OutOfOfficeDbContext context)
        {
            _context = context;
        }

        public async Task<PageResponse<Project>> Get(Pagination pagination, ProjectFilter projectFilter)
        {
            var query = _context.Projects.AsQueryable();

            /* Apply Filtering */

            // Project Type Filter
            if (projectFilter.ProjectTypes != null && projectFilter.ProjectTypes.Count > 0)
            {
                query = query.Where(p => projectFilter.ProjectTypes.Contains(p.ProjectType));
            }

            if (projectFilter.StartDate.HasValue)
            {
                query = query.Where(p => p.StartDate == projectFilter.StartDate);
            }

            if (projectFilter.EndDate.HasValue)
            {
                query = query.Where(p => p.EndDate == projectFilter.EndDate);
            }

            if (projectFilter.ProjectManagerId.HasValue)
            {
                query = query.Where(p => p.ProjectManager == projectFilter.ProjectManagerId);
            }
            else if (!string.IsNullOrEmpty(projectFilter.ProjectManagerName))
            {
                query = query.Where(p => p.ProjectManagerRef.FullName.Contains(projectFilter.ProjectManagerName));
            }

            if (projectFilter.Statuses != null && projectFilter.Statuses.Count > 0)
            {
                query = query.Where(p => projectFilter.Statuses.Contains(p.Status));
            }

            // Pagination
            var totalEntries = await query.CountAsync();
            var projects = await query
                .Skip((pagination.Page - 1) * pagination.Count)
                .Take(pagination.Count)
                .ToListAsync();

            return new PageResponse<Project>
            {
                Data = projects,
                Page = pagination.Page,
                TotalPages = (int)Math.Ceiling(totalEntries / (double)pagination.Count),
                TotalEntries = totalEntries
            };
        }

        public async Task<Project> GetById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task Create(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
