namespace IncidentManagement.Domain.Dtos.Contact
{
    public sealed record ContactDto(
        Guid Id,
        string Email,
        string FirstName,
        string LastName
    );
}