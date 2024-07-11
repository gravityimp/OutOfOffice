using Microsoft.AspNetCore.Mvc;
using OutOfOffice.Server.Data.Repositories;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Controllers
{
    [ApiController]
    [Route("api/leaveRequests")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get(
            [FromQuery] Pagination pagination,
            [FromQuery] LeaveRequestFilter filter
        )
        {
            return Ok(await _leaveRequestRepository.Get(pagination, filter));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetById(int id)
        {
            var requests = await _leaveRequestRepository.GetById(id);
            if (requests == null)
            {
                return NotFound();
            }
            return Ok(requests);
        }

        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> Create(LeaveRequest request)
        {
            await _leaveRequestRepository.Create(request);
            return CreatedAtAction("GetEmployee", new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LeaveRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            await _leaveRequestRepository.Update(request);
            return NoContent();
        }

        [HttpPut("{id}/submit")]
        public async Task<IActionResult> SubmitRequest(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelRequest(int id)
        {
            return NoContent();
        }
    }
}
