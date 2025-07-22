using IncidentManagement.Domain.Dtos.Account;
using IncidentManagement.Domain.Dtos.Contact;

namespace IncidentManagement.Domain.Dtos.Incident
{
    public sealed record FullIncidentDto(
        string Name,
        string Description,
        AccountDto Account,
        List<ContactDto> Contacts
    );
}