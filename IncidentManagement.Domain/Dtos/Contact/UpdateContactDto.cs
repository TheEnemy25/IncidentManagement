namespace IncidentManagement.Domain.Dtos.Contact
{
    public sealed record UpdateContactDto(
        Guid Id,
        string FirstName,
        string LastName
    );
}
