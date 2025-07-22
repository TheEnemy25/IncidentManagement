using AutoMapper;
using IncidentManagement.Data.Entities;
using IncidentManagement.Data.Repositories;
using IncidentManagement.Domain.Dtos.Contact;
using IncidentManagement.Domain.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Domain.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IBaseRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IBaseRepository<Contact> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactDto> CreateAsync(CreateContactDto dto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Contact>(dto);

            await _contactRepository.AddAsync(entity, cancellationToken);
            await _contactRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ContactDto>(entity);
        }

        public async Task<ContactDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _contactRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<ContactDto>(entity);
        }

        public async Task<ContactDto> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.Query()
                .FirstOrDefaultAsync(c => c.Email == email, cancellationToken);

            return contact == null ? null : _mapper.Map<ContactDto>(contact);
        }

        public async Task<ContactDto> UpdateAsync(UpdateContactDto dto, CancellationToken cancellationToken)
        {
            var entity = await _contactRepository.GetByIdAsync(dto.Id, cancellationToken);

            if (entity is null)
                throw new KeyNotFoundException($"Contact with Id {dto.Id} not found.");

            _mapper.Map(dto, entity);

            var updated = await _contactRepository.UpdateAsync(entity, cancellationToken);

            await _contactRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ContactDto>(updated);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _contactRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                throw new KeyNotFoundException($"Contact with Id {id} not found.");

            await _contactRepository.DeleteAsync(entity, cancellationToken);
            await _contactRepository.SaveChangesAsync(cancellationToken);
        }
    }
}