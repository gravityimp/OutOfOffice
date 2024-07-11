using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Models;
using OutOfOffice.Server.Models.Dto.Employee;

namespace OutOfOffice.Server.Controllers
{

    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get(
            [FromQuery] Pagination pagination,
            [FromQuery] EmployeeFilter employeeFilter
        )
        {
            var employees = await _employeeRepository.Get(pagination, employeeFilter);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<EmployeeDtoGet>(employee);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmployeeDtoPost employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.Create(employee);
            return Ok("Successully added new employee!");
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
