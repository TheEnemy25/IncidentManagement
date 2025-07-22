namespace IncidentManagement.Domain.Dtos.Contact
{
    public sealed record CreateContactDto(
        string Email,
        string FirstName,
        string LastName,
        Guid AccountId
    );
}