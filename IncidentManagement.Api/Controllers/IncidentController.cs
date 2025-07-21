using IncidentManagement.Domain.Dtos.Incident;
using IncidentManagement.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        private readonly IAccountService _accountService;

        public IncidentController(IIncidentService incidentService, IAccountService accountService)
        {
            _incidentService = incidentService;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFullIncidentDto dto, CancellationToken cancellationToken)
        {
            if (!await _accountService.ExistsAsync(dto.AccountName, cancellationToken))
                return NotFound("Account is not in the system");

            var result = await _incidentService.HandleFullIncidentCreationAsync(dto, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name, CancellationToken cancellationToken)
        {
            var result = await _incidentService.GetByNameAsync(name, cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateIncidentDto dto, CancellationToken cancellationToken)
        {
            var result = await _incidentService.UpdateAsync(dto, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name, CancellationToken cancellationToken)
        {
            await _incidentService.DeleteAsync(new DeleteIncidentDto(name), cancellationToken);

            return NoContent();
        }
    }
}
