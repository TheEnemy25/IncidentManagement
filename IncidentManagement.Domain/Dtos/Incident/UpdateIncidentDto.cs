namespace IncidentManagement.Domain.Dtos.Incident
{
    public sealed record UpdateIncidentDto(
        string Name,
        string Description
    );
}