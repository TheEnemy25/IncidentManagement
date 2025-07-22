namespace IncidentManagement.Domain.Dtos.Incident
{
    public sealed record IncidentDto(
        string Name,
        string Description
    );
}