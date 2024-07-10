using Microsoft.AspNetCore.Mvc;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Repositories;
using OutOfOffice.Server.Data.Repositories.Interfaces;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Controllers
{
    [ApiController]
    [Route("api/approvalRequests")]
    public class ApprovalRequestController : ControllerBase
    {
        private readonly IApprovalRequestRepository _approvalRequestRepository;

        public ApprovalRequestController(IApprovalRequestRepository approvalRequestRepository)
        {
            _approvalRequestRepository = approvalRequestRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get(
            [FromQuery] Pagination pagination,
            [FromQuery] ApprovalRequestFilter filter
        )
        {
            return Ok(await _approvalRequestRepository.Get(pagination, filter));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetById(int id)
        {
            var requests = await _approvalRequestRepository.GetById(id);
            if (requests == null)
            {
                return NotFound();
            }
            return Ok(requests);
        }

        [HttpPost]
        public async Task<ActionResult<ApprovalRequest>> Create(ApprovalRequest request)
        {
            await _approvalRequestRepository.Create(request);
            return CreatedAtAction("GetApprovalRequest", new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ApprovalRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            await _approvalRequestRepository.Update(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _approvalRequestRepository.Delete(id);
            return NoContent();
        }
    }
}
