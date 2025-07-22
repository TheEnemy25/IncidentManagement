namespace IncidentManagement.Domain.Dtos.Incident
{
    public sealed record CreateFullIncidentDto(
        string AccountName,
        string ContactFirstName,
        string ContactLastName,
        string ContactEmail,
        string IncidentDescription
    );
}