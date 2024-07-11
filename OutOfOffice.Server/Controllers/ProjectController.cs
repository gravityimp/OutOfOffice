using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Models;
using AutoMapper;
using OutOfOffice.Server.Models.Dto.Project;

namespace OutOfOffice.Server.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get(
            [FromQuery] Pagination pagination,
            [FromQuery] ProjectFilter filter
        )
        {
            var projects = await _projectRepository.Get(pagination, filter);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ProjectDtoGet>(project);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProjectDtoPost projectDto)
        {
            Project project = _mapper.Map<Project>(projectDto);
            await _projectRepository.Create(project);
            return Ok("Successully created new project!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest($"Id ({id}) does not match with project id ({project.Id})!");
            }

            await _projectRepository.Update(project);
            return Ok("Successfully updated project!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _projectRepository.Delete(id);
            return Ok("Successully deleted project!");
        }
    }
}
