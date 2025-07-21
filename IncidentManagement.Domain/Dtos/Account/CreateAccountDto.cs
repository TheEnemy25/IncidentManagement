namespace IncidentManagement.Domain.Dtos.Account
{
    public sealed record CreateAccountDto(
        string Name,
        string ContactFirstName,
        string ContactLastName,
        string ContactEmail
    );
}
