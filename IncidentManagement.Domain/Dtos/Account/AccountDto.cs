namespace IncidentManagement.Domain.Dtos.Account
{
    public sealed record AccountDto(
        Guid Id,
        string Name,
        string IncidentName
    );
}