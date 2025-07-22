using IncidentManagement.Domain.Dtos.Contact;

namespace IncidentManagement.Domain.Services.Abstractions
{
    public interface IContactService
    {
        Task<ContactDto> CreateAsync(CreateContactDto dto, CancellationToken cancellationToken);
        Task<ContactDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ContactDto> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<ContactDto> UpdateAsync(UpdateContactDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}