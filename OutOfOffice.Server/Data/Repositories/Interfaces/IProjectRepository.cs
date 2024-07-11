using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Models;
using OutOfOffice.Server.Models.Dto.Project;

namespace OutOfOffice.Server.Data.Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project, ProjectFilter>
    {
        public new Task<PageResponse<ProjectDtoGet>> Get(Pagination pagination, ProjectFilter filter);
    }
}
