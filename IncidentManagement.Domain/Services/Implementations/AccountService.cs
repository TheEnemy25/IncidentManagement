using AutoMapper;
using IncidentManagement.Data.Entities;
using IncidentManagement.Data.Repositories;
using IncidentManagement.Domain.Dtos.Account;
using IncidentManagement.Domain.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Domain.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<Account> _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IBaseRepository<Account> accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<AccountDto>(entity);
        }

        public async Task<AccountDto> CreateAsync(CreateAccountDto dto, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(dto);

            await _accountRepository.AddAsync(account, cancellationToken);
            await _accountRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> UpdateAsync(UpdateAccountDto dto, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.GetByIdAsync(dto.Id, cancellationToken);

            if (entity is null)
                throw new KeyNotFoundException($"Account with Id {dto.Id} not found.");

            _mapper.Map(dto, entity);

            var updated = await _accountRepository.UpdateAsync(entity, cancellationToken);

            await _accountRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<AccountDto>(updated);
        }

        public async Task DeleteAsync(DeleteAccountDto dto, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.GetByIdAsync(dto.Id, cancellationToken);

            if (entity is null)
                throw new KeyNotFoundException($"Account with Id {dto.Id} not found.");

            await _accountRepository.DeleteAsync(entity, cancellationToken);
            await _accountRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.Query().FirstOrDefaultAsync(x => x.Name == name, cancellationToken);

            return entity is not null;
        }
    }
}