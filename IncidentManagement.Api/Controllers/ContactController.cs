using IncidentManagement.Domain.Dtos.Contact;
using IncidentManagement.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactDto dto, CancellationToken cancellationToken)
        {
            var result = await _contactService.CreateAsync(dto, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _contactService.GetByIdAsync(id, cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email, CancellationToken cancellationToken)
        {
            var result = await _contactService.GetByEmailAsync(email, cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContactDto dto, CancellationToken cancellationToken)
        {
            var result = await _contactService.UpdateAsync(dto, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _contactService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}