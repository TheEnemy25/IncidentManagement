namespace IncidentManagement.Domain.Dtos.Account
{
    public sealed record UpdateAccountDto(
        Guid Id,
        string Name
    );
}