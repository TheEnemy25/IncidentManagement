using IncidentManagement.Domain.Dtos.Account;

namespace IncidentManagement.Domain.Services.Abstractions
{
    public interface IAccountService
    {
        Task<AccountDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<AccountDto> CreateAsync(CreateAccountDto dto, CancellationToken cancellationToken);
        Task<AccountDto> UpdateAsync(UpdateAccountDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(DeleteAccountDto dto, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(string name, CancellationToken cancellationToken);
    }
}
