using Microsoft.AspNetCore.Mvc;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Controllers
{

    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get(
            [FromQuery] Pagination pagination,
            [FromQuery] EmployeeFilter employeeFilter
        )
        {
            return Ok(await _employeeRepository.Get(pagination, employeeFilter));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            await _employeeRepository.Create(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.Delete(id);
            return NoContent();
        }
    }
}
