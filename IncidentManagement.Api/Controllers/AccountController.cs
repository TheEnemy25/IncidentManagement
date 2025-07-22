using IncidentManagement.Domain.Dtos.Account;
using IncidentManagement.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountDto dto, CancellationToken cancellationToken)
        {
            var result = await _accountService.CreateAsync(dto, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetByIdAsync(id, cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAccountDto dto, CancellationToken cancellationToken)
        {
            var result = await _accountService.UpdateAsync(dto, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _accountService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}