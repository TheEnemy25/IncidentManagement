using AutoMapper;
using IncidentManagement.Data.Entities;
using IncidentManagement.Data.Repositories;
using IncidentManagement.Domain.Dtos.Account;
using IncidentManagement.Domain.Dtos.Contact;
using IncidentManagement.Domain.Dtos.Incident;
using IncidentManagement.Domain.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Domain.Services.Implementations
{
    public class IncidentService : IIncidentService
    {
        private readonly IBaseRepository<Incident> _incidentRepository;
        private readonly IBaseRepository<Account> _accountRepository;
        private readonly IBaseRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public IncidentService(
            IBaseRepository<Incident> incidentRepository,
            IBaseRepository<Account> accountRepository,
            IBaseRepository<Contact> contactRepository,
            IMapper mapper)
        {
            _incidentRepository = incidentRepository;
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<FullIncidentDto> HandleFullIncidentCreationAsync(CreateFullIncidentDto dto, CancellationToken cancellationToken)
        {
            var account = await _accountRepository
             .Query()
             .Include(a => a.Contacts)
             .FirstOrDefaultAsync(a => a.Name == dto.AccountName, cancellationToken);

            if (account is null)
                throw new KeyNotFoundException("Account not found");

            var contact = await _contactRepository.Query().FirstOrDefaultAsync(c => c.Email == dto.ContactEmail, cancellationToken);

            if (contact is not null)
            {
                contact.FirstName = dto.ContactFirstName;
                contact.LastName = dto.ContactLastName;

                if (contact.AccountId != account.Id)
                    contact.AccountId = account.Id;

                await _contactRepository.UpdateAsync(contact, cancellationToken);
            }
            else
            {
                contact = new Contact
                {
                    FirstName = dto.ContactFirstName,
                    LastName = dto.ContactLastName,
                    Email = dto.ContactEmail,
                    AccountId = account.Id
                };

                await _contactRepository.AddAsync(contact, cancellationToken);
            }

            await _contactRepository.SaveChangesAsync(cancellationToken);

            var incident = new Incident
            {
                Description = dto.IncidentDescription,
                Accounts = [account],
            };

            await _incidentRepository.AddAsync(incident, cancellationToken);
            await _incidentRepository.SaveChangesAsync(cancellationToken);

            var result = new FullIncidentDto(
                incident.Name,
                incident.Description,
                _mapper.Map<AccountDto>(account),
                _mapper.Map<List<ContactDto>>(account.Contacts)
            );

            return result;
        }

        public async Task<IncidentDto> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var incident = await _incidentRepository.Query().FirstOrDefaultAsync(i => i.Name == name);

            return _mapper.Map<IncidentDto>(incident);
        }

        public async Task<IncidentDto> UpdateAsync(UpdateIncidentDto dto, CancellationToken cancellationToken)
        {
            var entity = await _incidentRepository.GetByIdAsync(dto.Name);
            entity.Description = dto.Description;

            var updated = await _incidentRepository.UpdateAsync(entity, cancellationToken);

            await _incidentRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<IncidentDto>(updated);
        }

        public async Task DeleteAsync(string name, CancellationToken cancellationToken)
        {
            var entity = await _incidentRepository.GetByIdAsync(name);

            if (entity is null)
                throw new KeyNotFoundException($"Incident with name '{name}' not found.");

            await _incidentRepository.DeleteAsync(entity, cancellationToken);
            await _incidentRepository.SaveChangesAsync(cancellationToken);
        }
    }
}