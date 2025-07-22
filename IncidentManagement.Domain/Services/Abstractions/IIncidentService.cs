using IncidentManagement.Domain.Dtos.Incident;

namespace IncidentManagement.Domain.Services.Abstractions
{
    public interface IIncidentService
    {
        Task<FullIncidentDto> HandleFullIncidentCreationAsync(CreateFullIncidentDto dto, CancellationToken cancellationToken);
        Task<IncidentDto> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<IncidentDto> UpdateAsync(UpdateIncidentDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(string name, CancellationToken cancellationToken);
    }
}