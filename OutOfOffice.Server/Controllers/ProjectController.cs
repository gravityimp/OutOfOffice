using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get(
            [FromQuery] Pagination pagination,
            [FromQuery] ProjectFilter filter
        )
        {
            return Ok(await _projectRepository.Get(pagination, filter));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetById(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Project project)
        {
            await _projectRepository.Create(project);
            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            await _projectRepository.Update(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectRepository.Delete(id);
            return NoContent();
        }
    }
}
